using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Sales_Date_Prediction.DTO;
using Sales_Date_Prediction.Interface;
using Sales_Date_Prediction.Models;
using System.Net;

namespace Sales_Date_Prediction.Repository
{
	public class OrderRepository : IOrderRepository
	{
		protected readonly AppDBContext _context;
		protected readonly IOrderDetail _orderDetailRepository;
		private readonly IMapper _mapper;
		public OrderRepository(AppDBContext context, IMapper mapper, IOrderDetail orderDetailRepository)
		{
			_context = context;
			_mapper = mapper;
			_orderDetailRepository = orderDetailRepository;
		}
		public async Task<IEnumerable<OrderDTO>> GetAllOrdersByCustomerAsync(int Custid)
		{
			try
			{
				if (Custid <= 0)
				{
					throw new ArgumentException("Invalid customer ID", nameof(Custid));
				}

				var orders = await _context.Orders
					.Where(o => o.Custid == Custid)
					.ProjectTo<OrderDTO>(_mapper.ConfigurationProvider)
					.ToListAsync();
				return orders;
			}
			catch (Exception msg)
			{
				// Log the exception (ex) here if needed
				throw new Exception($"Error while getting order {msg}");


			}
		}

		public async Task CreateOrderWithProducts(OrderWithDetailDTO orderDetailDTO)
		{
			using var transaction = await _context.Database.BeginTransactionAsync();
			try
			{
				if (orderDetailDTO == null)
				{
					throw new ArgumentNullException(nameof(orderDetailDTO), "Order cannot be null");
				}
				var order = _mapper.Map<Order>(orderDetailDTO);
				await _context.Orders.AddAsync(order);
				await _context.SaveChangesAsync();
				// Now that the order is created, we can set the OrderId in OrderDetail
				var detail = _mapper.Map<OrderDetail>(orderDetailDTO);
				detail.Orderid = order.Orderid; // Set the OrderId in OrderDetail
				await _orderDetailRepository.CreateOrderDetail(detail);
				await transaction.CommitAsync();

			}
			catch (DbUpdateException ex)
			{
				await transaction.RollbackAsync();
				throw new Exception($"Database update error: {ex.Message}", ex);
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				throw new Exception($"An error occurred while creating the order with product: {ex.Message}", ex);
			}
		}
	}
}

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
		private readonly IMapper _mapper;
		public OrderRepository(AppDBContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
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
	}
}

using Microsoft.EntityFrameworkCore;
using Sales_Date_Prediction.Interface;
using Sales_Date_Prediction.Models;

namespace Sales_Date_Prediction.Repository
{
	public class OrderRepository : IOrderRepository
	{
		protected readonly AppDBContext _context;
		public OrderRepository(AppDBContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<Order>> GetAllOrdersByCustomerAsync(int Custid)
		{
			try
			{
				if (Custid <= 0)
				{
					throw new ArgumentException("Invalid customer ID", nameof(Custid));
				}
				return await _context.Orders.Where(o => o.Custid == Custid).ToListAsync();
			}
			catch (Exception msg)
			{
				// Log the exception (ex) here if needed
				throw new Exception($"Error while getting order {msg}");


			}
		}
	}
}

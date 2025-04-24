using Sales_Date_Prediction.Interface;
using Sales_Date_Prediction.Models;

namespace Sales_Date_Prediction.Repository
{
	public class OrderDetailRepository : IOrderDetail
	{
		protected readonly AppDBContext _context;
		public OrderDetailRepository(AppDBContext context)
		{
			_context = context;
		}
		public async Task CreateOrderDetail(OrderDetail order)
		{
			try
			{
				_context.OrderDetails.Add(order);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				// Log the exception (ex) here if needed
				throw new Exception($"Error while creating order detail {ex}");

			}
		}

	}
}
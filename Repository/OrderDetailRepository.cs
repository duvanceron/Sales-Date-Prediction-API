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
			_context.OrderDetails.Add(order);
			await _context.SaveChangesAsync();
		}
	}

}

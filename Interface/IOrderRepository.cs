using Sales_Date_Prediction.Models;

namespace Sales_Date_Prediction.Interface
{
	public interface IOrderRepository
	{
		Task<IEnumerable<Order>> GetAllOrdersByCustomerAsync(int Custid);
	}
}

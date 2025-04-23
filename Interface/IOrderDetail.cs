using Sales_Date_Prediction.Models;

namespace Sales_Date_Prediction.Interface
{
	public interface IOrderDetail
	{

		Task CreateOrderDetail(OrderDetail order);

	}
}

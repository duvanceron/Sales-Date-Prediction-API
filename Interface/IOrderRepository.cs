using Sales_Date_Prediction.DTO;
using Sales_Date_Prediction.Models;

namespace Sales_Date_Prediction.Interface
{
	public interface IOrderRepository
	{
		Task<IEnumerable<OrderDTO>> GetAllOrdersByCustomerAsync(int Custid);
		Task CreateOrderWithProducts (OrderWithDetailDTO order);
	}
}

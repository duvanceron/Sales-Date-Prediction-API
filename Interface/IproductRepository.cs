using Sales_Date_Prediction.DTO;

namespace Sales_Date_Prediction.Interface
{
	public interface IproductRepository
	{
		Task<IEnumerable<ProductDTO>> GetAllEmployeesAsync();
	}
}

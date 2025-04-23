using Sales_Date_Prediction.DTO;
using Sales_Date_Prediction.Models;

namespace Sales_Date_Prediction.Interface
{
	public interface IEmployeeRepository
	{
		Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync();
	}
}

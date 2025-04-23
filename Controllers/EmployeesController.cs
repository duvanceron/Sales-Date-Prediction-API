using Microsoft.AspNetCore.Mvc;
using Sales_Date_Prediction.Interface;

namespace Sales_Date_Prediction.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class EmployeesController:ControllerBase
	{
		private readonly IEmployeeRepository _employeeRepository;
		public EmployeesController(IEmployeeRepository employeeRepository)
		{
			_employeeRepository = employeeRepository;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllEmployees()
		{
			var result = await _employeeRepository.GetAllEmployeesAsync();
			return Ok(result);
		}
	}
}

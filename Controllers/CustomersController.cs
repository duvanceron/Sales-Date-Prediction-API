using Microsoft.AspNetCore.Mvc;
using Sales_Date_Prediction.Interface;

namespace Sales_Date_Prediction.Controllers
{
	[Route("api/[controller]")]

	public class CustomersController : ControllerBase
	{
		private readonly ICustomerRepository _customerRepository;
		public CustomersController(ICustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;
		}
		[HttpGet("GetCustomerWithPredictedOrder")]
		public async Task<IActionResult> GetCustomerWithPredictedOrder()
		{
			var result = await _customerRepository.GetCustomerWithPredictedOrder();
			return Ok(result);
		}

	}
}

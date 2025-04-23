using Microsoft.AspNetCore.Mvc;
using Sales_Date_Prediction.Interface;

namespace Sales_Date_Prediction.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ShippersController : ControllerBase
	{
		private readonly IShipperRepository _shipperRepository;
		public ShippersController(IShipperRepository shipperRepository)
		{
			_shipperRepository = shipperRepository;
		}
		[HttpGet("GetShippers")]
		public async Task<IActionResult> GetShippers()
		{
			var result = await _shipperRepository.GetAllShippersAsync();
			return Ok(result);
		}
	
	}
}

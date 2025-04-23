using Microsoft.AspNetCore.Mvc;
using Sales_Date_Prediction.Interface;

namespace Sales_Date_Prediction.Controllers
{
	[ApiController]
	[Route("api/[controller]")]

	public class OrdersController:ControllerBase
	{

		private readonly IOrderRepository _orderRepository;
		public OrdersController(IOrderRepository orderRepository)
		{
			_orderRepository = orderRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllOrders(int Custid)
		{
			var result = await _orderRepository.GetAllOrdersByCustomerAsync(Custid);
			return Ok(result);
		}

	}
}

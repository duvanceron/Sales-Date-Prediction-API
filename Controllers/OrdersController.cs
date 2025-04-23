using Microsoft.AspNetCore.Mvc;
using Sales_Date_Prediction.DTO;
using Sales_Date_Prediction.Interface;
using Sales_Date_Prediction.Models;

namespace Sales_Date_Prediction.Controllers
{
	[ApiController]
	[Route("api/[controller]")]

	public class OrdersController : ControllerBase
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

		[HttpPost]
		public async Task<IActionResult> CreateOrderWithProduct([FromBody] OrderWithDetailDTO order)
		{
			if (order == null)
			{
				return BadRequest("Order or OrderDetail cannot be null");
			}
			await _orderRepository.CreateOrderWithProducts(order);
			return Ok("The order was created");
		}

	}
}

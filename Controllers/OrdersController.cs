using Microsoft.AspNetCore.Mvc;
using Sales_Date_Prediction.DTO;
using Sales_Date_Prediction.Interface;
using Sales_Date_Prediction.Models;
using Sales_Date_Prediction.Models.Response;
using System.Net;

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
				return BadRequest(ApiResponse<OrderWithDetailDTO>.ErrorResponse("Order or OrderDetail cannot be null", HttpStatusCode.BadRequest));

			}
			await _orderRepository.CreateOrderWithProducts(order);
			return Ok(ApiResponse<OrderWithDetailDTO>.SuccessResponse(order, "Pedido creado correctamente"));
		}

	}
}

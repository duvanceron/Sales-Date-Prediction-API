using Microsoft.AspNetCore.Mvc;
using Sales_Date_Prediction.Interface;

namespace Sales_Date_Prediction.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductController:ControllerBase
	{
		private readonly IProductRepository _productRepository;
		public ProductController(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllProducts()
		{
			var result = await _productRepository.GetAllProductsAsync();
			return Ok(result);
		}
	}
}

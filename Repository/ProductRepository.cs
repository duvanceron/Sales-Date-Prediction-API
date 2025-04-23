using AutoMapper;
using Sales_Date_Prediction.DTO;
using Sales_Date_Prediction.Interface;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace Sales_Date_Prediction.Repository
{
	public class ProductRepository : IProductRepository
	{
		protected readonly AppDBContext _context;
		private readonly IMapper _mapper;
		public ProductRepository(AppDBContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
		public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
		{
			try
			{
				var products = await _context.Products.ProjectTo<ProductDTO>(_mapper.ConfigurationProvider).ToListAsync();
				return products;
			}
			catch (Exception msg)
			{
				// Log the exception (ex) here if needed
				throw new Exception($"Error while getting products {msg}");


			}
		}
	}
}

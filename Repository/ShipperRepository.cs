using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Sales_Date_Prediction.DTO;
using Sales_Date_Prediction.Interface;

namespace Sales_Date_Prediction.Repository
{
	public class ShipperRepository : IShipperRepository
	{
		protected readonly AppDBContext _context;
		private readonly IMapper _mapper;

		public ShipperRepository(AppDBContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<IEnumerable<ShipperDTO>> GetAllShippersAsync()
		{
			try
			{
				var shippers = await _context.Shippers.ProjectTo<ShipperDTO>(_mapper.ConfigurationProvider).ToListAsync();

				return shippers;

			}
			catch (Exception msg)
			{
				throw new Exception($"Error while getting Shippers {msg}");
			}
		}
	}
}


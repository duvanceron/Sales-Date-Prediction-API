using AutoMapper;
using AutoMapper.QueryableExtensions;
using Sales_Date_Prediction.DTO;
using Sales_Date_Prediction.Interface;
using Sales_Date_Prediction.Models;
using Microsoft.EntityFrameworkCore;

namespace Sales_Date_Prediction.Repository
{
	public class EmployeeRepository : IEmployeeRepository
	{
		protected readonly AppDBContext _context;
		private readonly IMapper _mapper;
		public EmployeeRepository(AppDBContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync()
		{
			try
			{
				var employees = await _context.Employees.ProjectTo<EmployeeDTO>(_mapper.ConfigurationProvider).ToListAsync();

				return employees;

			}
			catch (Exception msg)
			{
				throw new Exception($"Error while getting Employee {msg}");
			}
		}
	}

}

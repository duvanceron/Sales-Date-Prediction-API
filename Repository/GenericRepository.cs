using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Sales_Date_Prediction.Interface;
using System.Linq.Expressions;

namespace Sales_Date_Prediction.Repository
{
	public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		protected readonly AppDBContext DBContext;
		protected DbSet<T> Entities;
		public GenericRepository(AppDBContext dBContext)
		{
			this.DBContext = dBContext;
			Entities = DBContext.Set<T>();
		}

		public async Task<IEnumerable<TResult>> GetSelectedAsync<TResult>(Expression<Func<T, TResult>> selector)
		{
			return await Entities
				.Select(selector)
				.ToListAsync();
		}
	}
}


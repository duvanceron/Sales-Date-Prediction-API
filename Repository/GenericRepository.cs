using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Sales_Date_Prediction.Interface;

namespace Sales_Date_Prediction.Repository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		protected readonly AppDBContext DBContext;
		protected DbSet<T> Entities;
		public GenericRepository(AppDBContext dBContext)
		{
			this.DBContext = dBContext;
			Entities = DBContext.Set<T>();
		}
		public async Task<T> InsertAsync(T entity)
		{
			if (entity == null) throw new ArgumentNullException(nameof(entity));
			EntityEntry<T> result = await Entities.AddAsync(entity);
			await DBContext.SaveChangesAsync();
			return result.Entity;
		}

		public async Task DeleteAsync(int id)
		{
			T? entity = await GetByIdAsync(id);
			if (entity == null) throw new Exception($"No se encontró la entidad con ID {id}");
			Entities.Remove(entity);
			await DBContext.SaveChangesAsync();
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await Entities.ToListAsync();
		}

		public async Task<T?> GetByIdAsync(int id)
		{
			return await Entities.FindAsync(id);
		}


		public async Task<T> UpdateAsync(T entity)
		{
			if (entity == null) throw new ArgumentNullException(nameof(entity));
			EntityEntry<T> result = Entities.Update(entity);
			await DBContext.SaveChangesAsync();
			return result.Entity;

		}
	}
}


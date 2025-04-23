namespace Sales_Date_Prediction.Interface
{
	public interface IGenericRepository<T>
	{
		Task<IEnumerable<T>> GetAllAsync();
		Task<T?> GetByIdAsync(int id);
		Task<T> InsertAsync(T entity);
		Task<T> UpdateAsync(T entity);
		Task DeleteAsync(int id);
	}
}

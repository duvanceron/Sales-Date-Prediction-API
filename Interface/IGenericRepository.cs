using System.Linq.Expressions;

namespace Sales_Date_Prediction.Interface
{
	public interface IGenericRepository<T>
	{
		Task<IEnumerable<TResult>> GetSelectedAsync<TResult>(Expression<Func<T, TResult>> selector);
	}
}

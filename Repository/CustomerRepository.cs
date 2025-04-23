using Microsoft.EntityFrameworkCore;
using Sales_Date_Prediction.DTO;
using Sales_Date_Prediction.Interface;
using Sales_Date_Prediction.Models;

namespace Sales_Date_Prediction.Repository
{
	public class CustomerRepository : ICustomerRepository
	{
		protected readonly AppDBContext _context;
		public CustomerRepository(AppDBContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<PredictedOrderDTO>> GetCustomerWithPredictedOrder()
		{
			try
			{
				var query = @"
            WITH OrderHistoric AS ( 
                SELECT 
                    O.custid,  
                    O.orderdate,
                    LAG(O.orderdate, 1, null) OVER (
                        PARTITION BY O.custid
                        ORDER BY O.orderdate
                    ) AS OrderPrev 
                FROM Sales.Orders AS O
            ), 
            QuantityDays AS(
                SELECT 
                    custid,
                    orderdate,
                    OrderPrev,
                    DATEDIFF(DAY, OrderPrev, orderdate) AS QDays
                FROM OrderHistoric 
            ),
            AVGOrder AS(
                SELECT 
                    custid,
                    MAX(orderdate) AS LastOrderDate,
                    AVG(CAST(QDays AS FLOAT)) AS AVGDays
                FROM QuantityDays
                GROUP BY custid
            )
            SELECT 
                C.companyname AS CustomerName,
                AO.LastOrderDate, 
                DATEADD(DAY, AO.AVGDays, AO.LastOrderDate) AS NextPredictedOrder
            FROM AVGOrder AO
            INNER JOIN Sales.Customers C ON AO.custid = C.custid
            ORDER BY C.custid;
        ";

				var predictedOrders = await _context
					.Set<PredictedOrderDTO>()
					.FromSqlRaw(query) // Aquí FromSqlRaw
					.ToListAsync();

				return predictedOrders;
			}
			catch (Exception msg)
			{
				throw new Exception($"Error while getting customer with predicted order {msg}");
			}
		}
	}
}

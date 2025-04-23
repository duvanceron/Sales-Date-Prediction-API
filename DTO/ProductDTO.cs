using System.ComponentModel.DataAnnotations;

namespace Sales_Date_Prediction.DTO
{
	public class ProductDTO
	{
		[Key]
		public int Productid { get; set; }

		public string Productname { get; set; } = null!;
	}
}

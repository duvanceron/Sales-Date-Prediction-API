using System.ComponentModel.DataAnnotations;

namespace Sales_Date_Prediction.DTO
{
	public class ShipperDTO
	{
		[Key]
		public int Shipperid { get; set; }

		public string Companyname { get; set; } = null!;

	}
}

namespace Sales_Date_Prediction.DTO
{
	public class PredictedOrderDTO
	{
		public string? CustomerName { get; set; }
		public DateTime? LastOrderDate { get; set; }
		public DateTime? NextPredictedOrder { get; set; }
	}
}

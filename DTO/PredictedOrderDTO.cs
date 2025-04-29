namespace Sales_Date_Prediction.DTO
{
	public class PredictedOrderDTO
	{
		public int Custid { get; set; }
		public string? CustomerName { get; set; }
		public DateTime? LastOrderDate { get; set; }
		public DateTime? NextPredictedOrder { get; set; }
	}
}

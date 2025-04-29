using System.Net;

namespace Sales_Date_Prediction.Models.Response
{
	public class ApiResponse<T>
	{
		public ApiResponse()
		{
			ErrorCode = (int)HttpStatusCode.OK;
			Message = string.Empty;
			Data = default!;
		}
		public ApiResponse(bool success, HttpStatusCode code, string message, T data)
		{
			Success = success;
			ErrorCode = (int)code;
			Message = message;
			Data = data;
		}
		public bool Success { get; set; } = true;
		public int ErrorCode { get; set; }
		public string Message { get; set; }
		public T? Data { get; set; }
		public static ApiResponse<T> SuccessResponse(T data, string message = "") =>
			new(true, HttpStatusCode.OK, message, data);
		public static ApiResponse<T> ErrorResponse(string message, HttpStatusCode code = HttpStatusCode.BadRequest) =>
			new(false, code, message, default!);
	}
}
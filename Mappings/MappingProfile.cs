using AutoMapper;
using Sales_Date_Prediction.DTO;
using Sales_Date_Prediction.Models;

namespace Sales_Date_Prediction.Mappings
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<PredictedOrderDTO, PredictedOrderDTO>();

		}
	}

}

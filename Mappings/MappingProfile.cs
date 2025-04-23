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
			CreateMap<Order, OrderDTO>();
			CreateMap<Employee, EmployeeDTO>()
					.ForMember(Edto => Edto.NameEmployee, opt => opt.MapFrom(E => E.Firstname + " " + E.Lastname));
			CreateMap<Shipper, ShipperDTO>();
			CreateMap<Product, ProductDTO>();
			CreateMap<OrderWithDetailDTO, Order>()
			.ForMember(dest => dest.OrderDetails, opt => opt.Ignore());

			CreateMap<OrderWithDetailDTO, OrderDetail>();

		}
	}

}

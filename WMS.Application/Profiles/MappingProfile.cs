using AutoMapper;
using WMS.Application.DTOs;
using WMS.Domain.Entities;

namespace WMS.Application.Profiles
{
    /// <summary>
    /// AutoMapper 映射配置，定义实体与 DTO 之间的转换规则
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// 构造函数，配置所有实体与 DTO 的映射关系
        /// </summary>
        public MappingProfile()
        {
            // 用户映射：User <-> UserDto
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.roleName, opt => opt.MapFrom(src => src.Role != null ? src.Role.Name : string.Empty))
                .ReverseMap();

            // 商品映射：Product <-> ProductDto
            CreateMap<Product, ProductDto>().ReverseMap();

            // 创建商品请求映射：CreateProductRequest -> Product
            CreateMap<CreateProductRequest, Product>();

            // 更新商品请求映射：UpdateProductRequest -> Product
            CreateMap<UpdateProductRequest, Product>();

            // 入库单映射：InboundOrder <-> InboundOrderDto
            CreateMap<InboundOrder, InboundOrderDto>()
                .ForMember(dest => dest.inboundTypeName, opt => opt.MapFrom(src => src.InboundType.ToString()))
                .ForMember(dest => dest.statusName, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.operatorName, opt => opt.MapFrom(src => src.Operator != null ? src.Operator.RealName : string.Empty))
                .ReverseMap();

            // 入库单明细映射：InboundOrderItem <-> InboundOrderItemDto
            CreateMap<InboundOrderItem, InboundOrderItemDto>()
                .ForMember(dest => dest.productCode, opt => opt.MapFrom(src => src.Product != null ? src.Product.Code : string.Empty))
                .ForMember(dest => dest.productName, opt => opt.MapFrom(src => src.Product != null ? src.Product.Name : string.Empty))
                .ReverseMap();

            // 创建入库单明细映射：CreateInboundOrderItemRequest -> InboundOrderItem
            CreateMap<CreateInboundOrderItemRequest, InboundOrderItem>();
        }
    }
}

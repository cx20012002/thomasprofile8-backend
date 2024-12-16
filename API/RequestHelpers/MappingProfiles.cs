using AutoMapper;
using API.Entities;
using API.Entities.Order;
using API.DTOs;

namespace API.RequestHelpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.Categories, o => o.MapFrom(s => s.Categories));

            CreateMap<Category, CategoryDto>()
                .ForMember(d => d.Slug, o => o.MapFrom(s => s.Name.ToLower().Replace(" ", "-")));

            CreateMap<Order, OrderDto>()
                .ForMember(d => d.Products, o => o.MapFrom(s => s.Products));

            CreateMap<Order, CreateOrderDto>()
                .ForMember(d => d.Products, o => o.MapFrom(s => s.Products));

            CreateMap<OrderProduct, OrderProductDto>()
                .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ItemOrdered.ProductId))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.ItemOrdered.Name))
                .ForMember(d => d.Price, o => o.MapFrom(s => s.ItemOrdered.Price))
                .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.ItemOrdered.PictureUrl));
        }
    }
}
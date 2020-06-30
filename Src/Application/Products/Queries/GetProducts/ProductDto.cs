using AutoMapper;
using ProductsCleanArch.Application.Common.Mappings;
using ProductsCleanArch.Domain.Entities;

namespace ProductsCleanArch.Application.Products.Queries.GetProducts
{
    public class ProductDto : IMapFrom<Product>
    {
        public int ProductId { get; set; }
        // public decimal UnitPrice { get; set; }
        public string ProductName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDto>();
        }
    }
}
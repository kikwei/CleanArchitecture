using AutoMapper;
using ProductsCleanArch.Application.Common.Mappings;
using ProductsCleanArch.Domain.Entities;

namespace ProductsCleanArch.Application.Products.Queries.GetProduct
{
    public class ProductVm : IMapFrom<Product>
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductVm>();
        }
    }

}
using AutoMapper;
using ProductsCleanArch.Application.Common.Mappings;
using ProductsCleanArch.Domain.Entities;

namespace ProductsCleanArch.Application.Products.Queries.GetProductsFile
{
    public class ProductRecordDto : IMapFrom<Product>
    {
        public string Category { get; set; }

        public string Name { get; set; }

        public decimal? UnitPrice { get; set; }

        public bool Discontinued { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductRecordDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.ProductName));
        }
    }
}

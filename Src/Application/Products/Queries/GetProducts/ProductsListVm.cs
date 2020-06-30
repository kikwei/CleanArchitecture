using System.Collections.Generic;

namespace ProductsCleanArch.Application.Products.Queries.GetProducts
{
    public class ProductsListVm
    {
        public IList<ProductDto> Products { get; set; }
    }
}
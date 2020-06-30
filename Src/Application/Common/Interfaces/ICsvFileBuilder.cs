using System.Collections.Generic;
using ProductsCleanArch.Application.Products.Queries.GetProductsFile;

namespace ProductsCleanArch.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildProductsFile(IEnumerable<ProductRecordDto> records);
    }
}

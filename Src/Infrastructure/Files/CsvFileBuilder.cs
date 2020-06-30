using System.Collections.Generic;
using System.IO;
using CsvHelper;
using ProductsCleanArch.Application.Common.Interfaces;
using ProductsCleanArch.Application.Products.Queries.GetProductsFile;

namespace ProductsCleanArch.Infrastructure.Files
{
    public class CsvFileBuilder : ICsvFileBuilder
    {
        public byte[] BuildProductsFile(IEnumerable<ProductRecordDto> records)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter((ISerializer)streamWriter);
                csvWriter.Configuration.RegisterClassMap<ProductFileRecordMap>();
                csvWriter.WriteRecords(records);
            }

            return memoryStream.ToArray();
        }
    }
}

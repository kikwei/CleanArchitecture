using System.Collections.Generic;
using ProductsCleanArch.Domain.Common;

namespace ProductsCleanArch.Domain.Entities
{
    public class Product : AuditableEntity
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
    }
}

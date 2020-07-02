using ProductsCleanArch.Domain.Common;

namespace ProductsCleanArch.Domain.Entities
{
    public class User : AuditableEntity
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Occupation { get; set; }
        public int Age { get; set; }
    }
}
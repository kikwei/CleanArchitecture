using Microsoft.EntityFrameworkCore;
using ProductsCleanArch.Application.Common.Interfaces;
using ProductsCleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProductsCleanArch.Application
{
    public class SampleDataSeeder
    {
        private readonly IProductsCleanArchDbContext _context;
        private readonly IUserManager _userManager;

        private readonly Dictionary<int, Product> Products = new Dictionary<int, Product>();

        public SampleDataSeeder(IProductsCleanArchDbContext context, IUserManager userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task SeedAllAsync(CancellationToken cancellationToken)
        {

            await SeedProductsAsync(cancellationToken);
        }





        private async Task SeedProductsAsync(CancellationToken cancellationToken)
        {
            Products.Add(1, new Product { ProductName = "Chai", UnitPrice = 18.00m });
            Products.Add(2, new Product { ProductName = "Chang", UnitPrice = 19.00m });
            Products.Add(3, new Product { ProductName = "Aniseed Syrup", UnitPrice = 10.00m });
            Products.Add(4, new Product { ProductName = "Chef Anton's Cajun Seasoning", UnitPrice = 22.00m });
            Products.Add(5, new Product { ProductName = "Chef Anton's Gumbo Mix", UnitPrice = 21.35m });
            Products.Add(6, new Product { ProductName = "Grandma's Boysenberry Spread", UnitPrice = 25.00m });
            Products.Add(7, new Product { ProductName = "Uncle Bob's Organic Dried Pears", UnitPrice = 30.00m });
            Products.Add(8, new Product { ProductName = "Northwoods Cranberry Sauce", UnitPrice = 40.00m });
            Products.Add(9, new Product { ProductName = "Mishi Kobe Niku", UnitPrice = 97.00m });
            Products.Add(10, new Product { ProductName = "Ikura", UnitPrice = 31.00m });
            Products.Add(11, new Product { ProductName = "Queso Cabrales", UnitPrice = 21.00m });
            Products.Add(12, new Product { ProductName = "Queso Manchego La Pastora", UnitPrice = 38.00m });
            Products.Add(13, new Product { ProductName = "Konbu", UnitPrice = 6.00m });
            Products.Add(14, new Product { ProductName = "Tofu", UnitPrice = 23.25m });
            Products.Add(15, new Product { ProductName = "Genen Shouyu", UnitPrice = 15.50m });
            Products.Add(16, new Product { ProductName = "Pavlova", UnitPrice = 17.45m });
            Products.Add(17, new Product { ProductName = "Alice Mutton", UnitPrice = 39.00m });
            Products.Add(18, new Product { ProductName = "Carnarvon Tigers", UnitPrice = 62.50m });
            Products.Add(19, new Product { ProductName = "Teatime Chocolate Biscuits", UnitPrice = 9.20m });
            Products.Add(20, new Product { ProductName = "Sir Rodney's Marmalade", UnitPrice = 81.00m });

            foreach (var product in Products.Values)
            {
                _context.Products.Add(product);
            }

            await _context.SaveChangesAsync(cancellationToken);
        }


        private static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                .ToArray();
        }
    }

}
using System.Collections.Generic;
using Backend.Interfaces;
using Backend.Models;

namespace Backend.Services
{
    public class ProductsService : IProductsService
    {
        public IEnumerable<Product> Products()
            => new List<Product>
                {
                    new Product
                    {
                        Id = 1,
                        Name = "Product 1"
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Product 2"
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Product 3"
                    }
                };
    }
}
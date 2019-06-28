using System.Collections.Generic;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface IProductsService
    {
        IEnumerable<Product> Products();
    }
}
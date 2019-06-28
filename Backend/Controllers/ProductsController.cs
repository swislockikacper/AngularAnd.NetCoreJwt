using System.Collections.Generic;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService service;

        public ProductsController(IProductsService service)
        {
            this.service = service;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("api/products")]
        public IEnumerable<Product> Products()
            => service.Products();
    }
}

using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Dtos;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductController: ControllerBase
    {
        private static List<Product> Products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1000},
            new Product { Id = 2, Name = "Smartphone", Price = 600 },
            new Product { Id = 3, Name = "Tv", Price = 600 },
            new Product { Id = 4, Name = "Tv1", Price = 600 },
            new Product { Id = 5, Name = "Tv2", Price = 600 },
            new Product { Id = 6, Name = "Tv3", Price = 600 },
            new Product { Id = 7, Name = "Tv4", Price = 600 },
            new Product { Id = 8, Name = "Tv5", Price = 600 },
            new Product { Id = 9, Name = "Tv6", Price = 600 },
            new Product { Id = 10, Name = "Tv7", Price = 600 },
            new Product { Id = 11, Name = "Tv8", Price = 600 },
        };

        [HttpGet]
        public IActionResult GetAllProducts(int pageIndex, int pageSize)
        {
            var products = Products.
                OrderBy(p => p.Id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize).ToList();

            var count = Products.Count;
            var totalPages = (int)Math.Ceiling(count /(double) pageSize);

            var paginatedList = new PaginatedList<Product>(products, pageIndex, totalPages);
            return Ok(paginatedList);
        }

        [HttpPost]
        public IActionResult AddProduct(ProductCreateDto product)
        {
            var newProduct = new Product
            {
                Id = Products.Count + 1,
                Name = product.Name,
                Price = product.Price
            };
            Products.Add(newProduct);
            return Ok(newProduct);
        }

        [HttpPut()]
        public IActionResult UpdateProduct(ProductDto productDto)
        {
            var product = Products.FirstOrDefault(p => p.Id == productDto.Id);
            if (product == null) 
            {
                return NotFound("Product not found");
            }
            product.Name = productDto.Name;
            product.Price = productDto.Price;
            return Ok(product);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound("Product not found.");

            }
            Products.Remove(product);
            return Ok("Product deleted.");
        }

        
    }
}

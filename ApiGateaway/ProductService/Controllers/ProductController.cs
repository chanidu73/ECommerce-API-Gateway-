using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductService.Models;
using ProductService.Services;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController:ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService productService)
        {
            _service = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _service.GetAllProductsAsync();
            return Ok(products);
        }
        [HttpPost]
        public async Task<IActionResult>AddProduct(ProductModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _service.AddProductAsync(model);
            return Ok(model);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _service.GetProductByIdAsync(id);
            if(product == null)return NotFound("There is no product called that id ");
            return Ok(product);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteProduct (int id)
        {
            var product = await _service.GetProductByIdAsync(id);
            if(product == null)return NotFound();
            await _service.DeleteProductAsync(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateProduct(int id , ProductModel model)
        {
            if(id != model.ProductId)
            {
                return BadRequest();
            }
            if(!ModelState.IsValid) return BadRequest();
            await _service.UpdateProductAsync(model);
            return Ok(model);
        }
    }
}
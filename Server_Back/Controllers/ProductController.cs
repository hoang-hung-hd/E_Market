﻿using Microsoft.AspNetCore.Mvc;
using Server_Back.Models;
using Server_Back.Services;

namespace Server_Back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }   

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var product = _productService.GetById(id);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(Product_Request model)
        {
            _productService.Create(model);
            return Ok(new { message = "Product created" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Product_Request model)
        {
            _productService.Update(id, model);
            return Ok(new { message = "Product updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return Ok(new { message = "Product deleted" });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ProductsController : BaseAPIController
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
            
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Product>>>GetAllProducts()
        {
            var response=await _context.Products.ToListAsync();
            if(response.Any())return Ok(response);
            return NotFound("No Products Found!");
        }
        [HttpGet("GetProductById/{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var response=await _context.Products.FindAsync(id);
            if(response !=null)return Ok(response);
            return NotFound($"Response with id {id} is not found!");
        }
    }
}
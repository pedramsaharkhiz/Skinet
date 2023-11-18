using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Specification;

namespace API.Controllers
{
    public class ProductsController : BaseAPIController
    {
        public IProductsRepository Repository { get; }

        public ProductsController(IProductsRepository repository)
        {
            Repository = repository;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            // var response = await Repository.GetAll();
            var spec = new ProductsWithTypesAndBrandsSpecification();
            var response = await Repository.ListAsyncWithSpec(spec);
            if (response.Any())
                return Ok(response);
            return NotFound("No Products Found!");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            // var response = await Repository.GetById(id);
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var response = await Repository.GetEntityWithSpec(spec);
            if (response != null)
                return Ok(response);
            return NotFound($"Response with id {id} is not found!");
        }

        [HttpGet]
        [Route("GetOdds")]
        public async Task<ActionResult<IEnumerable<Product>>> GetOdds()
        {
            var response = await Repository.GetOddProducts();
            if (response.Any())
                return Ok(response);
            return NotFound();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController : BaseAPIController
    {
        [HttpGet("{quantity}")]
        public async Task<int> GetProductCount(int quantity)
        {
            return  quantity*2;
        }
    }
}
﻿using BigSizeFashion.Business.Helpers.Parameters;
using BigSizeFashion.Business.Helpers.RequestObjects;
using BigSizeFashion.Business.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigsizeFashion.API.Controllers
{
    [Route("api/v1/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        //[Authorize]
        //[HttpGet("all")]
        //public async Task<IActionResult> GetListProductsWithAllStatus([FromQuery] SearchProductsParameter param)
        //{
        //    var result = await _service.GetListProductsWithAllStatus(param);
        //    return Ok(result);
        //}

        //[Authorize]
        //public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
        //{
        //    var result = await _service.CreateProduct(request);
        //    return Ok(result);
        //}
    }
}

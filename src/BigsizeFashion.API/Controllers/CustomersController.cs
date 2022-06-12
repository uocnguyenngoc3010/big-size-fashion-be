﻿using BigSizeFashion.Business.Helpers.RequestObjects;
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
    [Route("api/v1/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService _service;

        public CustomersController(ICustomersService service)
        {
            _service = service;
        }

        /// <summary>
        /// Allow customer get their own profile
        /// </summary>
        /// <param name="authorization"></param>
        /// <returns></returns>
        //[Authorize]
        [HttpGet("get-own-profile")]
        public async Task<IActionResult> GetOwnProfile([FromHeader] string authorization)
        {
            var result = await _service.GetOwnProfile(authorization.Substring(7));
            return Ok(result);
        }

        /// <summary>
        /// Allow customer update their own profile
        /// </summary>
        /// <remarks>
        /// - Birthday is string and must have format is dd/MM/yyyy
        /// - Example: 01/01/2022
        /// </remarks>
        /// <param name="authorization"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        //[Authorize]
        [HttpPut("update-profile")]
        public async Task<IActionResult> UpdateProfile([FromHeader] string authorization, [FromBody] UpdateCustomerProfileRequest request)
        {
            var result = await _service.UpdateProfile(authorization.Substring(7), request);
            return Ok(result);
        }

        /// <summary>
        /// Allow customer create PIN code
        /// </summary>
        /// <remarks>
        /// - PIN code have 6 number characters
        /// - Return true if create successful
        /// - Return false if this customer is existed PIN code
        /// </remarks>
        /// <param name="authorization"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        //[Authorize]
        [HttpPost("create-pin-code")]
        public async Task<IActionResult> CreatePINCode([FromHeader] string authorization, [FromBody] CreatePINCodeRequest request)
        {
            var result = await _service.CreatePINCode(authorization.Substring(7), request);
            return Ok(result);
        }

        /// <summary>
        /// Allow customer change PIN code
        /// </summary>
        /// <remarks>
        /// - PIN code have 6 number characters
        /// - Return true if change successful
        /// - Return false if wrong Old Pin code
        /// </remarks>
        /// <param name="authorization"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        //[Authorize]
        [HttpPut("change-pin-code")]
        public async Task<IActionResult> ChangePINCode([FromHeader] string authorization, [FromBody] ChangePINCodeRequest request)
        {
            var result = await _service.ChangePINCode(authorization.Substring(7), request);
            return Ok(result);
        }

        /// <summary>
        /// Check this customer is had PIN code or not
        /// </summary>
        /// <remarks>
        /// - Return true if existed
        /// - Return false if not and require customer create PIN code
        /// </remarks>
        /// <param name="authorization"></param>
        /// <returns></returns>
        //[Authorize]
        [HttpGet("check-pin-code")]
        public async Task<IActionResult> CheckPINCode([FromHeader] string authorization)
        {
            var result = await _service.CheckPINCode(authorization.Substring(7));
            return Ok(result);
        }

        /// <summary>
        /// Validate PIN code when customer want to check out their Cart
        /// </summary>
        /// <remarks>
        /// - PIN code have 6 number characters
        /// - Return true if right Pin code
        /// - Return false if wrong Pin code
        /// </remarks>
        /// <param name="authorization"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        //[Authorize]
        [HttpPost("validate-pin-code")]
        public async Task<IActionResult> ValidatePINCode([FromHeader] string authorization, [FromBody] ValidatePINCodeRequest request)
        {
            var result = await _service.ValidatePINCode(authorization.Substring(7), request);
            return Ok(result);
        }
    }
}

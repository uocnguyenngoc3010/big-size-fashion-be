﻿using BigSizeFashion.Business.Dtos.Parameters;
using BigSizeFashion.Business.Dtos.Requests;
using BigSizeFashion.Business.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigsizeFashion.API.Controllers
{
    [Route("api/v1/inventory-notes")]
    [ApiController]
    public class InventoryNotesController : ControllerBase
    {
        private readonly IInventoryNoteService _service;

        public InventoryNotesController(IInventoryNoteService service)
        {
            _service = service;
        }

        /// <summary>
        /// Tạo phiếu kiểm kê
        /// </summary>
        /// <param name="authorization"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateInventoryNote([FromHeader] string authorization, [FromBody] CreateInventoryNoteRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _service.CreateInventoryNote(authorization.Substring(7), request);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        /// <summary>
        /// Get detail inventory note by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInventoryNoteById(int id)
        {
            var result = await _service.GetInventoryNoteById(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        /// <summary>
        /// get list Inventory Note
        /// </summary>
        /// <param name="authorization"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetListInventoryNote([FromHeader] string authorization, [FromQuery] GetListInventoryNoteParameter param)
        {
            var result = await _service.GetListInventoryNote(authorization.Substring(7), param);
            return Ok(result);
        }

        /// <summary>
        /// Delete Inventory Note
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventoryNote(int id)
        {
            var result = await _service.DeleteInventoryNote(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        /// <summary>
        /// Export excel file for Inventory Note
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[HttpGet("export-excel/{id}")]
        //public async Task<IActionResult> ExportExcel(int id)
        //{
        //    var result = await _service.ExportExcel(id);
        //    if (!result.IsSuccess)
        //    {
        //        return BadRequest(result);
        //    }
        //    return Ok(result);
        //}
    }
}

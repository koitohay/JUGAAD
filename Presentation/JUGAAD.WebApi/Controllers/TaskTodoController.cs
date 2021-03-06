﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JUGAAD.Application.Features.TaskFeatures.Commands;
using JUGAAD.Application.Features.TaskFeatures.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JUGAAD.WebApi.Controllers
{
    [ApiVersion("1.0")]
    public class TaskTodoController : BaseApiController
    {
        /// <summary>
        /// Creates a New Product.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        /// <summary>
        /// Gets all Products.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllTaskTodoQuery()));
        }
        ///// <summary>
        ///// Gets Product Entity by Id.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    return Ok(await Mediator.Send(new GetProductByIdQuery { Id = id }));
        //}
        ///// <summary>
        ///// Deletes Product Entity based on Id.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    return Ok(await Mediator.Send(new DeleteProductByIdCommand { Id = id }));
        //}
        ///// <summary>
        ///// Updates the Product Entity based on Id.   
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="command"></param>
        ///// <returns></returns>
        //[HttpPut("[action]")]
        //public async Task<IActionResult> Update(int id, UpdateProductCommand command)
        //{
        //    if (id != command.Id)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(await Mediator.Send(command));
        //}
    }
}
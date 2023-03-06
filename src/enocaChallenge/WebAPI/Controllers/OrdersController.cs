using Application.Features.Order.Commands.CreateOrder;
using Application.Features.Order.Dtos;
using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreatedOrderDto addOrderDto)
        {
            var data = await Mediator.Send(new AddOrderCommand.Command(addOrderDto));
            return Created("", data);
        }
    }
}

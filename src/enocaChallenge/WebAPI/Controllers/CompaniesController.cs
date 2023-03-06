using Application.Features.Companies.Commands.CreateCompany;
using Application.Features.Companies.Commands.DeleteCompany;
using Application.Features.Companies.Commands.UpdateCompany;
using Application.Features.Companies.Dtos;
using Application.Features.Companies.Queries.GetListCompany;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateCompanyCommand createCompanyCommands)
        {
            CreatedCompanyDto result = await Mediator.Send(createCompanyCommands);
            return Created("", result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCompanyCommand deleteCompanyCommand)
        {
            DeletedCompanyDto result = await Mediator.Send(deleteCompanyCommand);
            return Ok(result);
        }


        /// <summary>
        /// Update the IsActive
        /// </summary>
        /// <param name="updateCompanyCommand"></param>
        /// <returns></returns>
        [HttpPut("UpdateIsActive")]
        public async Task<IActionResult> UpdateIsActive([FromBody] UpdateIsActiveCommand updateCompanyCommand)
        {
            UpdatedIsActiveDto result = await Mediator.Send(updateCompanyCommand);
            return Ok(result);
        }


        [HttpPut("UpdateOrderDate")]
        public async Task<IActionResult> UpdateOrderDate([FromBody] UpdateOrderDateCommand updateCompanyCommand)
        {
            UpdatedOrderDateDto result = await Mediator.Send(updateCompanyCommand);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = await Mediator.Send(new GetListCompanyQuery.Query());
            return Ok(data);
        }

    }
}

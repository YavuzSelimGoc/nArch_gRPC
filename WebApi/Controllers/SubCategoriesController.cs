using Application.Features.SubCategory.Commands.Create;
using Application.Features.SubCategory.Queries.GetList;
using Application.Features.SubCategorys.Commands.Create;
using Application.Features.SubCategorys.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriesController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSubCategoryCommand createSubCategoryCommand)
        {
            CreatedSubCategoryResponse response = await Mediator.Send(createSubCategoryCommand);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListSubCategoryQuery getListSubCategoryQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListSubCategoryListItemDto> response = await Mediator.Send(getListSubCategoryQuery);
            return Ok(response);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById([FromRoute] Guid id)
        //{
        //    GetByIdSubCategoryQuery getByIdSubCategoryQuery = new() { Id = id };
        //    GetByIdSubCategoryResponse response = await Mediator.Send(getByIdSubCategoryQuery);
        //    return Ok(response);
        //}

        //[HttpPut]
        //public async Task<IActionResult> Update([FromBody] UpdateSubCategoryCommand updateSubCategoryCommand)
        //{
        //    UpdatedSubCategoryResponse response = await Mediator.Send(updateSubCategoryCommand);

        //    return Ok(response);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete([FromRoute] Guid id)
        //{
        //    DeletedSubCategoryResponse response = await Mediator.Send(new DeleteSubCategoryCommand { Id = id });

        //    return Ok(response);
        //}
    }
}
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using Application.Features.ProgrammingLanguageTechnologies.Commands;
using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Application.Features.SocialMediaAddresses.Commands;
using Application.Features.SocialMediaAddresses.Dtos;
using Application.Features.SocialMediaAddresses.Models;
using Application.Features.SocialMediaAddresses.Queries.GetByIdSocialMediaAddress;
using Application.Features.SocialMediaAddresses.Queries.GetListSocialMediaAddress;
using Core.Application.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class SocialMediaAddressController : BaseController
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Add([FromBody] CreatedSocialMediaAddressCommand createdSocialMediaAddressCommand)
        {
            CreatedSocialMediaAddressDto result = await Mediator.Send(createdSocialMediaAddressCommand);
            return Created("", result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdatedSocialMediaAddressCommand updatedSocialMediaAddressCommand)
        {
            UpdatedSocialMediaAddressDto result = await Mediator.Send(updatedSocialMediaAddressCommand);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] DeletedSocialMediaAddressCommand deletedSocialMediaAddressCommand)
        {
            DeletedSocialMediaAddressDto result = await Mediator.Send(deletedSocialMediaAddressCommand);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListSocialMediaAddressQuery getListSocialMediaAddressQuery = new() { PageRequest = pageRequest };

            SocialMediaAddressListModel result = await Mediator.Send(getListSocialMediaAddressQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdSocialMediaAddressQuery getByIdSocialMediaAddressQuery)
        {
            SocialMediaAddressGetByIdDto socialMediaAddressGetByIdDto = await Mediator.Send(getByIdSocialMediaAddressQuery);
            return Ok(socialMediaAddressGetByIdDto);
        }
    }
}

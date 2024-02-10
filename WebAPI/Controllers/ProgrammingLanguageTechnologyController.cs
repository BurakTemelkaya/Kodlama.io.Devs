using Application.Features.ProgrammingLanguages.Commands;
using Application.Features.ProgrammingLanguageTechnologies.Commands;
using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Application.Features.ProgrammingLanguageTechnologies.Models;
using Application.Features.ProgrammingLanguageTechnologies.Queries.GetByIdProgrammingLanguageTechnology;
using Application.Features.ProgrammingLanguageTechnologies.Queries.GetListProgrammingLanguageTechnology;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguageTechnologyController : BaseController
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageTechnologyCommand createProgramingLanguageTechnologyCommand)
        {
            CreateProgrammingLanguageTechnologyDto result = await Mediator.Send(createProgramingLanguageTechnologyCommand);
            return Created("", result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdatedProgrammingLanguageTechnologyCommand updatedProgramingLanguageTechnologyCommand)
        {
            UpdateProgrammingLanguageTechnologyDto result = await Mediator.Send(updatedProgramingLanguageTechnologyCommand);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] DeletedProgrammingLanguageTechnologyCommand deletedProgramingLanguageTechnologyCommand)
        {
            DeletedProgrammingLanguageTechnologyDto result = await Mediator.Send(deletedProgramingLanguageTechnologyCommand);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingLanguageTechnologyQuery getListProgrammingLanguageTechnologyQuery = new() { PageRequest = pageRequest };

            ProgrammingLanguageTechnologyListModel result = await Mediator.Send(getListProgrammingLanguageTechnologyQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLanguageTechnologyQuery getByIdProgrammingLanguageTechnologyQuery)
        {
            ProgrammingLanguageTechnologyGetByIdDto programmingLanguageTechnologyGetByIdDto = await Mediator.Send(getByIdProgrammingLanguageTechnologyQuery);
            return Ok(programmingLanguageTechnologyGetByIdDto);
        }
    }
}

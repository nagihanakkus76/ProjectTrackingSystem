using Microsoft.AspNetCore.Mvc;
using ProjectTrackingSystem.Application.Features.Projects.Commands.Create;
using ProjectTrackingSystem.Application.Features.Projects.Commands.Delete;
using ProjectTrackingSystem.Application.Features.Projects.Commands.Update;
using ProjectTrackingSystem.Application.Features.Projects.Queries.GetById;
using ProjectTrackingSystem.Application.Features.Projects.Queries.GetList;

namespace ProjectTrackingSystem.WebAPI.Controllers
{

    public class ProjectsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]  
        public async Task<IActionResult> DeleteProject([FromRoute] int id)
        {
            DeleteProjectCommand command = new DeleteProjectCommand() { ID = id};
            await _mediator.Send(command);
            return Ok("Proje Başarıyla Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProject([FromBody] UpdateProjectCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);    
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProject([FromRoute]int id)
        {
            GetByIdProjectQuery query = new GetByIdProjectQuery() { ID = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetListProject()
        {
            var result = await _mediator.Send(new GetListProjectQuery());
            return Ok(result);
        }
    }
}

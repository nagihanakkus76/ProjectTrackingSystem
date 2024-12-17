using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTrackingSystem.Application.Features.Tasks.Commands.ChangeStatus;
using ProjectTrackingSystem.Application.Features.Tasks.Commands.Create;
using ProjectTrackingSystem.Application.Features.Tasks.Commands.Delete;
using ProjectTrackingSystem.Application.Features.Tasks.Commands.Update;
using ProjectTrackingSystem.Application.Features.Tasks.Queries.GetList;
using ProjectTrackingSystem.Domain.Enum;

namespace ProjectTrackingSystem.WebAPI.Controllers
{

    public class TasksController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTask([FromBody] UpdateTaskCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask([FromRoute] int id)
        {
            DeleteTaskCommand command = new DeleteTaskCommand() { ID = id };
            await _mediator.Send(command);
            return Ok("Görev Başarıyla Silindi.");
        }

        [HttpPut("{id}/change-status/{statusID}")]
        public async Task<IActionResult> ChangeStatus([FromRoute] int id, [FromRoute] Status statusID)
        {
            ChangeStatusTaskCommand command = new ChangeStatusTaskCommand() { ID = id, Status = statusID };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}/change-status/new")]
        public async Task<IActionResult> ChangeStatusNew([FromRoute]int id)
        {
            ChangeStatusTaskCommand command = new ChangeStatusTaskCommand() { ID = id, Status = Status.New};
            var result = await _mediator.Send(command);
            return Ok(result);  
        }

        [HttpPut("{id}/change-status/in-progress")]
        public async Task<IActionResult> ChangeStatusInProgress([FromRoute] int id)
        {
            ChangeStatusTaskCommand command = new ChangeStatusTaskCommand() { ID = id, Status = Status.InProgress };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}/change-status/completed")]
        public async Task<IActionResult> ChangeStatusCompleted([FromRoute] int id)
        {
            ChangeStatusTaskCommand command = new ChangeStatusTaskCommand() { ID = id, Status = Status.Completed };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetListTask()
        {
            var result = await _mediator.Send(new  GetListTaskQuery()); 
            return Ok(result);  
        }
    }

}
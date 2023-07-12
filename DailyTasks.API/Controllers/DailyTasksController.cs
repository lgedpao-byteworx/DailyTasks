using MediatR;
using Microsoft.AspNetCore.Mvc;
using DailyTasks.Domain.Entities;
using DailyTasks.Application.Features;

namespace DailyTasks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DailyTasksController : ControllerBase
    {
        private readonly ILogger<DailyTasksController> _logger;
        private readonly IMediator _mediator;

        public DailyTasksController(ILogger<DailyTasksController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<DailyTask> GetById([FromRoute] string id)
        {
            return await _mediator.Send(new GetDailyTaskByIdQuery(id));
        }

        [HttpGet]
        public async Task<List<DailyTask>> GetAll()
        {
            return await _mediator.Send(new GetDailyTaskQuery());
        }

        [HttpPost]
        public async Task<DailyTask> Create([FromBody] CreateDailyTaskCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<DailyTask> Update([FromRoute] string id, [FromBody] UpdateDailyTaskRequest request)
        {
            var command = new UpdateDailyTaskCommand(id, request.Title, request.Description, request.DueDate);
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<Unit> DeleteById([FromRoute] string id)
        {
            return await _mediator.Send(new DeleteDailyTaskCommand(id));
        }
    }
}
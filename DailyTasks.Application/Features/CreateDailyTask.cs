using MediatR;
using DailyTasks.Domain.Entities;
using DailyTasks.Domain.Interfaces;

namespace DailyTasks.Application.Features
{
    public record CreateDailyTaskCommand(string Title, string Description, DateTime? DueDate) : IRequest<DailyTask>;

    public class CreateDailyTaskCommandHandler : IRequestHandler<CreateDailyTaskCommand, DailyTask>
    {
        private readonly IRepository<DailyTask> _repository;
        public CreateDailyTaskCommandHandler(IRepository<DailyTask> repository)
        {
            _repository = repository;
        }

        public async Task<DailyTask> Handle(CreateDailyTaskCommand request, CancellationToken cancellationToken)
        {
            var dailyTask = new DailyTask
            {
                Id = Guid.NewGuid().ToString(),
                Title = request.Title,
                Description = request.Description,
                DueDate = request.DueDate,
                CreateDate = DateTime.UtcNow,
            };

            return await _repository.Create(dailyTask);
        }
    }
}

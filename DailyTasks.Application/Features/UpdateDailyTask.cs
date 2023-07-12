using DailyTasks.Domain.Entities;
using DailyTasks.Domain.Interfaces;
using MediatR;

namespace DailyTasks.Application.Features
{
    public record UpdateDailyTaskCommand(string Id, string Title, string Description, DateTime? DueDate) : IRequest<DailyTask>;

    public record UpdateDailyTaskRequest(string Title, string Description, DateTime? DueDate);

    public class UpdateDailyTaskCommandHandler : IRequestHandler<UpdateDailyTaskCommand, DailyTask>
    {
        private readonly IRepository<DailyTask> _repository;
        public UpdateDailyTaskCommandHandler(IRepository<DailyTask> repository)
        {
            _repository = repository;
        }

        public async Task<DailyTask> Handle(UpdateDailyTaskCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repository.GetById(request.Id);

            if (existing != null)
            {
                existing.Title = request.Title;
                existing.Description = request.Description;
                existing.DueDate = request.DueDate;

                return await _repository.Update(existing);
            }

            return null;           
        }
    }
}

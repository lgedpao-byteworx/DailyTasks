using DailyTasks.Domain.Entities;
using DailyTasks.Domain.Interfaces;
using MediatR;

namespace DailyTasks.Application.Features
{
    public record DeleteDailyTaskCommand(string Id) : IRequest<Unit>;
    public class DeleteDailyTaskCommandHandler : IRequestHandler<DeleteDailyTaskCommand, Unit>
    {
        private readonly IRepository<DailyTask> _repository;
        public DeleteDailyTaskCommandHandler(IRepository<DailyTask> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteDailyTaskCommand request, CancellationToken cancellationToken)
        {
             await _repository.DeleteById(request.Id);

            return Unit.Value;
        }
    }
}

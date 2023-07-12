using MediatR;
using DailyTasks.Domain.Entities;
using DailyTasks.Domain.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace DailyTasks.Application.Features
{
    public record GetDailyTaskByIdQuery(string Id) : IRequest<DailyTask>;

    public class GetDailyTaskByIdQueryHandler : IRequestHandler<GetDailyTaskByIdQuery, DailyTask>
    {
        private readonly IRepository<DailyTask> _repository;
        public GetDailyTaskByIdQueryHandler(IRepository<DailyTask> repository)
        {
            _repository = repository;
        }

        public async Task<DailyTask> Handle(GetDailyTaskByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetById(request.Id);
        }
    }
}

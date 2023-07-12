using DailyTasks.Domain.Entities;
using DailyTasks.Domain.Interfaces;
using MediatR;

namespace DailyTasks.Application.Features
{
    public record GetDailyTaskQuery : IRequest<List<DailyTask>>;
    public class GetDailyTaskQueryHandler : IRequestHandler<GetDailyTaskQuery, List<DailyTask>>
    {
        private readonly IRepository<DailyTask> _repository;
        public GetDailyTaskQueryHandler(IRepository<DailyTask> repository)
        {
            _repository = repository;
        }

        public async Task<List<DailyTask>> Handle(GetDailyTaskQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}

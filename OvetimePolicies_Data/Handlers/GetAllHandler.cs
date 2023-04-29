using OvetimePolicies_Core.Dtos;
using OvetimePolicies_Data.Repositories;

namespace OvetimePolicies_Data.Handlers;

sealed public class GetAllHandler
{
    private readonly IQueryRepository _repository;

    public GetAllHandler(IQueryRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<PersonDto>> Handle()
    {
        return await _repository.GetAll();
    }

}

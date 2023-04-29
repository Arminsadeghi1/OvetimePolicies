using OvetimePolicies_Core.Dtos;
using OvetimePolicies_Data.Repositories;

namespace OvetimePolicies_Data.Handlers;

sealed public class GetByIdHandler
{
    private readonly IQueryRepository _repository;

    public GetByIdHandler(IQueryRepository repository)
    {
        _repository = repository;
    }

    public async Task<PersonDto> Handle(Guid id)
    {
        return await _repository.GetById(id);
    }

}

using OvetimePolicies_Core.Dtos;
using OvetimePolicies_Core.Entities;

namespace OvetimePolicies_Data.Repositories;

public interface IQueryRepository
{
    public Task<PersonDto> GetById(Guid id);

    public Task<List<PersonDto>> GetAll();
}

using OvetimePolicies_Core.Dtos;

namespace OvetimePolicies_Data.Repositories;

public interface IRepository
{
    public Task<Guid> AddPerson(AddPersonDto person);

    public Task EditPerson(EditPersonDto person);

    public Task DeletePerson(Guid id);
}

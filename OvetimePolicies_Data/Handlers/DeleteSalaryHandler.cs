using OvetimePolicies_Data.Repositories;
using OvetimePolicies_dlls;

namespace OvetimePolicies_Data.Handlers;

sealed public class DeleteSalaryHandler
{
    private IRepository _repository;

    public DeleteSalaryHandler(CalculatorHandler handler, IRepository repository)
    {
        _repository = repository;
    }


    public async Task Handle(Guid id)
    {

        await _repository.DeletePerson(id);
    }
}

using OvetimePolicies_Core.Dtos;
using OvetimePolicies_Data.Repositories;
using OvetimePolicies_dlls;

namespace OvetimePolicies_Data.Handlers;

sealed public class EditSalaryHandler
{
    private IRepository _repository;

    public EditSalaryHandler(CalculatorHandler handler, IRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(EditPersonDto dto)
    {

        await _repository.EditPerson(dto);
    }
}

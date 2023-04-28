using OvetimePolicies_Core.Dtos;
using OvetimePolicies_Core.Entities;

namespace OvetimePolicies_Data.Repositories;

sealed public class Repository : IRepository
{
    private readonly ApplicationDBContext _context;

    public Repository(ApplicationDBContext context)
    {
        _context = context;
    }

    private async Task<Person> Load(Guid id)
    {
        return await _context.FindAsync<Person>(id);
    }


    public async Task<Guid> AddPerson(AddPersonDto person)
    {
        var entity = new Person(person);
       await _context.AddAsync(entity);

        return entity.Id;
    }

    public async Task EditPerson(EditPersonDto person)
    {
        var entity = await Load(person.Id);

        entity.FirstName = person.FirstName;
        entity.LastName = person.LastName;
        entity.BasicSalary = person.BasicSalary;
        entity.Allowance = person.Allowance;
        entity.Transportation = person.Transportation;
        entity.TotalIncome = person.TotalIncome;
        entity.Date = person.Date;

        await _context.SaveChangesAsync();
    }

    public async Task DeletePerson(Guid id)
    {
        _context.Remove(id);
        await _context.SaveChangesAsync(); //ToDo: Use unit of work for commit changes
    }
}

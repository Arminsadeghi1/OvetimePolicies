using OvetimePolicies_Core.Dtos;

namespace OvetimePolicies_Core.Entities;


sealed public class Person
{

    public Person(AddPersonDto dto)
    {
        this.Id = Guid.NewGuid();

        this.FirstName = dto.FirstName;
        this.LastName = dto.LastName;
        this.BasicSalary = dto.BasicSalary;
        this.Allowance = dto.Allowance;
        this.Transportation = dto.Transportation;
        this.TotalIncome = dto.TotalIncome;
        this.Date = dto.Date;
    }

    public Guid Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal BasicSalary { get; set; }
    public decimal? Allowance { get; set; }
    public decimal? Transportation { get; set; }
    public decimal TotalIncome { get; set; }
    public DateTime Date { get; set; }
}

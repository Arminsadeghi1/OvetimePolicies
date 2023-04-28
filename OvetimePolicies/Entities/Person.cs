namespace OvetimePolicies_api.Entities;

sealed public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal BasicSalary { get; set; }
    public decimal? Allowance { get; set; }
    public decimal? Transportation { get; set; }
    public decimal TotalIncome { get; set; }
    public DateTime Date { get; set; }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OvetimePolicies_Core.Dtos;

sealed public class EditCommandDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal BasicSalary { get; set; }
    public decimal Allowance { get; set; }
    public decimal Transportation { get; set; }
    public decimal TotalIncome { get; set; }
    public DateTime Date { get; set; }
}

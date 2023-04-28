using System;

namespace _01_OvetimePolicies_domain.Entities
{
    sealed public class person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal? Allowance { get; set; }
        public decimal? Transportation { get; set; }
        public decimal TotalIncome { get; set; }
        public DateTime Date { get; set; }
    }
}

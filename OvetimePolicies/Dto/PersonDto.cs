namespace OvetimePolicies_api.Dto
{
    sealed public class PersonDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public decimal? BasicSalary { get; set; }
        public decimal? Allowance { get; set; }
        public decimal? Transportation { get; set; }
        public DateTime? Date { get; set; }
    }
}

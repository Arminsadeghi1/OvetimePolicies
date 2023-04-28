namespace OvetimePolicies_api.Dtos;

sealed public class CommandDto
{
    public PersonDto data { get; set; }

    public string overTimeCalculator { get; set; }
}

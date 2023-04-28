namespace OvetimePolicies_Core.Dtos;

sealed public class AddCommandDto
{
    public PersonDto data { get; set; }

    public string overTimeCalculator { get; set; }
}

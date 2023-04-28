using OvetimePolicies_api.Dtos;
using OvetimePolicies_api.Exception;
using OvetimePolicies_dlls;

namespace OvetimePolicies_api.Handlers;

sealed public class AddSalaryHandler
{
    private CalcurlatorHandler _calcurlator;
    public AddSalaryHandler(CalcurlatorHandler handler)
    {
        _calcurlator = handler;
    }

    public async Task AddSalary(CommandDto commandDto)
    {
        var overTime = await calcuteOverTime(commandDto);

        //deductions like taxes
        var deductions = 0; 

        var Incomes =
            commandDto.data.BasicSalary +
            commandDto.data.Allowance +
            commandDto.data.Transportation +
            overTime;

        var total = Incomes - deductions;



    }

    private async Task<decimal> calcuteOverTime(CommandDto command)
    {
        switch (command.overTimeCalculator.ToLower())
        {
            case "calcurlatora":
                return await _calcurlator.CalcurlatorA(command.data.BasicSalary.Value, command.data.Allowance.Value);

            case "calcurlatorb":
                return await _calcurlator.CalcurlatorB(command.data.BasicSalary.Value, command.data.Allowance.Value);

            case "calcurlatorc":
                return await _calcurlator.CalcurlatorC(command.data.BasicSalary.Value, command.data.Allowance.Value);

            default:
                throw new CalcurlatorMethodeNotFoundException();
        }
    }
}
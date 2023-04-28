using OvetimePolicies_Core.Dtos;
using OvetimePolicies_Core.Exception;
using OvetimePolicies_Data.Repositories;
using OvetimePolicies_dlls;

namespace OvetimePolicies_Data.Handlers;

sealed public class AddSalaryHandler
{
    private CalculatorHandler _calculator;
    private IRepository _repository;

    public AddSalaryHandler(CalculatorHandler handler, IRepository repository)
    {
        _calculator = handler;
        _repository = repository;
    }

    public async Task AddSalary(AddCommandDto commandDto)
    {
        var overTime = await calcuteOverTime(commandDto);

        //deductions like taxes
        var totalDeductions = 0;

        var totalIncomes =
            commandDto.data.BasicSalary +
            commandDto.data.Allowance +
            commandDto.data.Transportation +
            overTime;

        var total = totalIncomes - totalDeductions;

        var AddDto = new AddPersonDto()
        {
            FirstName = commandDto.data.FirstName,
            LastName = commandDto.data.LastName,
            Allowance = commandDto.data.Allowance,
            BasicSalary = commandDto.data.BasicSalary,
            Date = commandDto.data.Date,
            Transportation = commandDto.data.Transportation,
            TotalIncome = total
        };

        await _repository.AddPerson(AddDto);
    }

    private async Task<decimal> calcuteOverTime(AddCommandDto command)
    {
        switch (command.overTimeCalculator.ToLower())
        {
            case "calculatora":
                return await _calculator.CalculatorA(command.data.BasicSalary, command.data.Allowance);

            case "calculatorb":
                return await _calculator.CalculatorB(command.data.BasicSalary, command.data.Allowance);

            case "calculatorc":
                return await _calculator.CalculatorC(command.data.BasicSalary, command.data.Allowance);

            default:
                throw new CalculatorMethodeNotFoundException();
        }
    }
}
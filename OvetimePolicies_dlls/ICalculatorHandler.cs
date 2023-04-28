using System.Threading.Tasks;

namespace OvetimePolicies_dlls
{
    public interface ICalculatorHandler
    {

        public Task<decimal> CalculatorA(decimal basicSalary, decimal allowance);

        public Task<decimal> CalculatorB(decimal basicSalary, decimal allowance);

        public Task<decimal> CalculatorC(decimal basicSalary, decimal allowance);
    }
}

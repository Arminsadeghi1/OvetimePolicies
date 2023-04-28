using System.Threading.Tasks;

namespace OvetimePolicies_dlls
{
    sealed public class CalculatorHandler : ICalculatorHandler
    {
        public CalculatorHandler()
        {
            
        }

        public async Task<decimal> CalculatorA(decimal basicSalary, decimal allowance)
        {
            var amount = basicSalary + allowance;
            return (amount * (decimal)1.3);
        }

        public async Task<decimal> CalculatorB(decimal basicSalary, decimal allowance)
        {
            var amount = basicSalary + allowance;
            return (amount * (decimal)1.4);
        }

        public async Task<decimal> CalculatorC(decimal basicSalary, decimal allowance)
        {
            var amount = basicSalary + allowance;
            return (amount * (decimal)1.5);
        }
    }
}

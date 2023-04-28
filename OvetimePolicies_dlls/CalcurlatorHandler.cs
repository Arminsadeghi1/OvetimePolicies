using System.Threading.Tasks;

namespace OvetimePolicies_dlls
{
    sealed public class CalcurlatorHandler : ICalcurlatorHandler
    {
        public CalcurlatorHandler()
        {
            
        }

        public async Task<decimal> CalcurlatorA(decimal basicSalary, decimal allowance)
        {
            var amount = basicSalary + allowance;
            return (amount * (decimal)1.3);
        }

        public async Task<decimal> CalcurlatorB(decimal basicSalary, decimal allowance)
        {
            var amount = basicSalary + allowance;
            return (amount * (decimal)1.4);
        }

        public async Task<decimal> CalcurlatorC(decimal basicSalary, decimal allowance)
        {
            var amount = basicSalary + allowance;
            return (amount * (decimal)1.5);
        }
    }
}

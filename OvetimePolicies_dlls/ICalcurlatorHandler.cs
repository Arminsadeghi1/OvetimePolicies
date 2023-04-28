using System.Threading.Tasks;

namespace OvetimePolicies_dlls
{
    public interface ICalcurlatorHandler
    {

        public Task<decimal> CalcurlatorA(decimal basicSalary, decimal allowance);

        public Task<decimal> CalcurlatorB(decimal basicSalary, decimal allowance);

        public Task<decimal> CalcurlatorC(decimal basicSalary, decimal allowance);
    }
}

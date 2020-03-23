using System;
using System.Threading.Tasks;

namespace TaxCalculation
{
    public interface ICalculator
    {

        Task<double> GetTaxRate(string zip);
        double CalculateTaxes(Order order);
    }
}

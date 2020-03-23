
using System.Threading.Tasks;

namespace TaxCalculation
{
    public class TaxService
    {
        //to implement strategy I would set up a DI container then i would create a calculator strategy factory interface
        //then inside the concrete implementation i would pass the order in based off of the order calculate tax field i would base different 
        //implementations off of that for different calculators that may be implemented now or in the future. but with one calculator I do not see 
        //it necessary to add the complexity
        private readonly ICalculator _calculator;

        public TaxService(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public double GetTaxRateAsync(string zip)
        {
           return _calculator.GetTaxRate(zip).Result;
        }

        public double CalculateTaxes(Order order)
        {
            return _calculator.CalculateTaxes(order);
        }
    }
}

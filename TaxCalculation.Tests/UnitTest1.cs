using System;
using Xunit;

namespace TaxCalculation.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var sut = new TaxService(new TaxJar());
            var res = sut.GetTaxRateAsync("34997");
            Assert.True(res == .065);
        }

        [Fact]
        public void Test2()
        {
            
            Order ord = new Order() { Total = 34.95 , Zip= "34997"};
            var sut = new TaxService(new TaxJar());
            var res = sut.CalculateTaxes(ord);
            Assert.True(res == 37.22);
        }
    }
}

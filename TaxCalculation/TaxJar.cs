using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculation
{
    public class TaxJar : ICalculator
    {
        private readonly HttpClient _client = new HttpClient();
        private double TaxRate { get; set; } = 0.0;


        public double CalculateTaxes(Order order) 
        {

            _ = GetTaxRate(order.Zip).Result;

            var res = order.Total + (order.Total * TaxRate);
            return Math.Round(res, 2);
        }
        public async Task<double> GetTaxRate(string zip)
        {
            try
            {
                _client.BaseAddress = new Uri("https://api.taxjar.com/v2/");
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "fd34e58295836bd3a17c841b4ff03f6e");
                var result = _client.GetAsync($"rates/{zip}").Result;
                result.EnsureSuccessStatusCode();
                string responseBody = await result.Content.ReadAsStringAsync();
                JToken token = JObject.Parse(responseBody);
                var rate = Convert.ToDouble(token.SelectToken("rate").SelectToken("combined_rate").ToString());
                TaxRate = rate;
                return rate;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}

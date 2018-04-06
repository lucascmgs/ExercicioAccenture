using ExercicioAccenture.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ExercicioAccenture.Services
{
    public class Markets
    {
        public List<Market> Content{ get; set; }
        public DateTime RequestTime { get; set; }

        public void FetchMarkets(string coin1, string coin2)
        {
            List<Market> result = new List<Market>();
            if (coin1 != coin2)
            {
                string text = "<!DOCTYPE HTML>";
                do
                {
                    string URL = "https://api.cryptonator.com/api/full/";
                    string arguments = coin1 + "-" + coin2;
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(URL);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.GetAsync(arguments).Result;
                    if (response.IsSuccessStatusCode)
                    {

                        text = response.Content.ReadAsStringAsync().Result;

                    }
                } while (text.Contains("<!DOCTYPE html>"));

                Console.WriteLine(text);

                Newtonsoft.Json.Linq.JObject values = Newtonsoft.Json.Linq.JObject.Parse(text);

                foreach (var k in values.SelectToken("ticker").SelectToken("markets"))
                {
                    result.Add(new Market { Name = k.SelectToken("market").ToString(), Price = Double.Parse(k.SelectToken("price").ToString(), CultureInfo.InvariantCulture) });
                }
                result.Sort((x, y) => x.Price.CompareTo(y.Price));
            }
            this.Content = result;
        }
    }

}

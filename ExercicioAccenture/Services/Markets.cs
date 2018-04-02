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
        public List<Market> Mercados { get; set; }

        public void FetchMarkets(string Coin1, string Coin2)
        {
            string URL = "https://api.cryptonator.com/api/full/";
            string arguments = Coin1 + "-" + Coin2;
            List<Market> resultado = new List<Market>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(arguments).Result;
            if (response.IsSuccessStatusCode)
            {

                var resposta = response.Content.ReadAsStringAsync().Result;
                Newtonsoft.Json.Linq.JObject valores = Newtonsoft.Json.Linq.JObject.Parse(resposta);
                foreach (var k in valores.SelectToken("ticker").SelectToken("markets"))
                {
                    resultado.Add(new Market { Name = k.SelectToken("market").ToString(), Price = Double.Parse(k.SelectToken("price").ToString(), CultureInfo.InvariantCulture) });
                }
            }
            resultado.Sort((x, y) => x.Price.CompareTo(y.Price));

            this.Mercados = resultado;
        }
    }

}

using Newtonsoft.Json;
using ExercicioAccenture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExercicioAccenture.Services
{
    public static class ExistingCoins
    {
        private const string URL = "https://www.cryptonator.com/api/currencies";



        public static List<Coin> RequestCoins()
        {
            List<Coin> result = new List<Coin>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                var texto = response.Content.ReadAsStringAsync().Result;
                Newtonsoft.Json.Linq.JObject valores = Newtonsoft.Json.Linq.JObject.Parse(texto);
                foreach (var k in valores.SelectToken("rows"))
                {
                    result.Add(new Coin { Name = k.SelectToken("name").ToString(), Code = k.SelectToken("code").ToString()} );
                }

            }
            result.Sort((x, y) => x.Name.CompareTo(y.Name));

            return result;

        }
    }
}

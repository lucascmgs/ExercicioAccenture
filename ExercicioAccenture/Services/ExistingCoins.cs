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
            List<Coin> resultado = new List<Coin>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                var resposta = response.Content.ReadAsStringAsync().Result;
                Newtonsoft.Json.Linq.JObject valores = Newtonsoft.Json.Linq.JObject.Parse(resposta);
                foreach (var k in valores.SelectToken("rows"))
                {
                    resultado.Add(new Coin { Name = k.SelectToken("name").ToString(), Code = k.SelectToken("code").ToString()} );
                }

            }
            resultado.Sort((x, y) => x.Name.CompareTo(y.Name));

            return resultado;

        }
    }
}

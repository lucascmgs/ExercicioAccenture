using ExercicioAccenture.Models;
using ExercicioAccenture.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace ExercicioAccenture.Services
{
    public static class RequestedExchanges
    {

        public static async Task<ShowExchangesViewModel> FetchMarkets(string coin1, string coin2)
        {
            List<Exchange> result = new List<Exchange>();
            if (coin1 == coin2)
            {
                throw new Exception("The coins are the same. No results.");
            }

            var watch = System.Diagnostics.Stopwatch.StartNew();


            string text = "<!DOCTYPE html>";
            while (text.Contains("<!DOCTYPE html>"))
            {
                string URL = "https://api.cryptonator.com/api/full/";
                string arguments = coin1 + "-" + coin2;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(arguments);
                if (response.IsSuccessStatusCode)
                {
                    text = response.Content.ReadAsStringAsync().Result;
                }
                if (watch.ElapsedMilliseconds > 8000)
                {
                    watch.Stop();
                    throw new TimeoutException();
                }
            }

            
            RequestedExchangeData values = new RequestedExchangeData();

            try
            {
                values = Newtonsoft.Json.JsonConvert.DeserializeObject<RequestedExchangeData>(text);

            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception("The pair of coins does not have registered Exchanges");
            }

            result = values.Ticker.Markets;

            result.Sort((x, y) => x.Price.CompareTo(y.Price));


            return new ShowExchangesViewModel { Exchanges = result, RequestTime = TimeStampToDateTime(values.Timestamp)};
        }

        public static DateTime TimeStampToDateTime(double unixTimeStamp)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }

}

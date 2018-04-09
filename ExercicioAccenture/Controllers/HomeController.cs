using ExercicioAccenture.Models;
using ExercicioAccenture.Services;
using ExercicioAccenture.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExercicioAccenture.Controllers
{
    
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            var resultado = new List<SelectListItem>();
            var coins = ExistingCoins.RequestCoins();
            foreach (Coin k in coins)
            {
                resultado.Add(new SelectListItem
                {
                    Text = k.Name + " (" + k.Code + ")",
                    Value = k.Code
                });
            }
            ViewBag.CoinList = resultado;
            return View();
        }

        public async Task<IActionResult> ShowExchanges(string coin1, string coin2)
        {
            ShowExchangesViewModel model = new ShowExchangesViewModel();
            ViewBag.coin1 = coin1;
            ViewBag.coin2 = coin2;
            ViewBag.ErrorMessage = "";

            
            
            try
            {
                if (RedisConnectorHelper.CheckKeys(coin1, coin2))
                {
                    string exc = RedisConnectorHelper.GetExchanges(coin1, coin2);

                    model = Newtonsoft.Json.JsonConvert.DeserializeObject<ShowExchangesViewModel>(exc);

                    return View(model);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            

            try
            {
                model = await RequestedExchanges.FetchMarkets(coin1, coin2);
                
                
            } catch(Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
            }
            try
            {
                RedisConnectorHelper.SetExchanges(coin1, coin2, model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return View(model);
        }
    }
}

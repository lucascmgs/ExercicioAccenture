using ExercicioAccenture.Models;
using ExercicioAccenture.Services;
using ExercicioAccenture.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

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

        public IActionResult ShowExchanges(string coin1, string coin2)
        {
            ShowExchangesViewModel model = new ShowExchangesViewModel();
            ViewBag.coin1 = coin1;
            ViewBag.coin2 = coin2;
            try
            {
                model.WantedExchanges.FetchMarkets(coin1, coin2);
                ViewBag.ErrorMessage = "";
            } catch(Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
            }
            
            
            model.RequestTime = DateTime.Now;
            return View(model);
        }
    }
}

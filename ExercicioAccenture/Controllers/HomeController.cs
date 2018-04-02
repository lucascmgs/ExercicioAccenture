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

        public IActionResult ShowMarkets(string Coin1, string Coin2)
        {
            ShowMarketsViewModel model = new ShowMarketsViewModel();
            model.Mercados.FetchMarkets(Coin1, Coin2);
            model.HoraRequisicao = DateTime.Now;
            return View(model);
        }
    }
}

using ExercicioAccenture.Models;
using ExercicioAccenture.Services;
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
                    Text = "(" + k.Code + ") " + k.Name,
                    Value = k.Code
                });
            }
            ViewBag.CoinList = resultado;
            return View();
        }

        public IActionResult ShowMarkets(string Coin1, string Coin2)
        {
            Console.WriteLine("{0} {1}", Coin1, Coin2 );
            return View();
        }
    }
}

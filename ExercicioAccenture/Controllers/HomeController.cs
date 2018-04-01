﻿using ExercicioAccenture.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExercicioAccenture.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            ViewBag.CoinList = ExistingCoins.GetAllCodes();
            return View();
        }
    }
}

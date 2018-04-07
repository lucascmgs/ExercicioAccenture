using ExercicioAccenture.Models;
using ExercicioAccenture.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExercicioAccenture.ViewModels
{
    public class ShowExchangesViewModel
    {
        public List<Exchange> Exchanges { get; set; }
        public DateTime RequestTime { get; set; }
        public ShowExchangesViewModel()
        {
            this.Exchanges = new List<Exchange>();
            this.RequestTime = new DateTime();
        }
    }
}

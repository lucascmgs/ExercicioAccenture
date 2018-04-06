using ExercicioAccenture.Models;
using ExercicioAccenture.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExercicioAccenture.ViewModels
{
    public class ShowMarketsViewModel
    {
        public Markets WantedExchanges { get; set; }
        public DateTime RequestTime { get; set; }
        public ShowMarketsViewModel()
        {
            this.WantedExchanges = new Markets();
            this.RequestTime = new DateTime();
        }
    }
}

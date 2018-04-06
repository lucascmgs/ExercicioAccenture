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
        public RequestedExchanges WantedExchanges { get; set; }
        public DateTime RequestTime { get; set; }
        public ShowExchangesViewModel()
        {
            this.WantedExchanges = new Services.RequestedExchanges();
            this.RequestTime = new DateTime();
        }
    }
}

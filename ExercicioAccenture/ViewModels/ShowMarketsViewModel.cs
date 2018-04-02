using ExercicioAccenture.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExercicioAccenture.ViewModels
{
    public class ShowMarketsViewModel
    {
        public Markets Mercados { get; set; }
        public DateTime HoraRequisicao { get; set; }
        public ShowMarketsViewModel()
        {
            this.Mercados = new Markets();
            this.HoraRequisicao = new DateTime();
        }
    }
}

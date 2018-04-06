using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExercicioAccenture.Models
{
    public class DataTicker
    {
        public string Base { get; set; }
        public string Target { get; set; }
        public double Price { get; set; }
        public double Volume { get; set; }
        public double Change { get; set; }
        public List<Exchange> Markets { get; set; }
    }
}

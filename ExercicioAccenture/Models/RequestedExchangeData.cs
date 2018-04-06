using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExercicioAccenture.Models
{
    public class RequestedExchangeData
    {
        public DataTicker Ticker { get; set; }
        public double Timestamp { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
    }
}

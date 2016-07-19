using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Identity.Models
{
    public class TesteModelBinder
    {
        public string Nome { get; set; }

        public decimal Decimal1 { get; set; }

        public decimal? Decimal2 { get; set; }
    }
}
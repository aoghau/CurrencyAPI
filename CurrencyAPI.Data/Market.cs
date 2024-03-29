﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyAPI.Data
{
    public class Market
    {
        public int id { get; set; }
        public string exchangeId { get; set; }
        public string baseId { get; set; }
        public string quoteId { get; set; }
        public string baseSymbol { get; set; }
        public string quoteSymbol { get; set; }
        public string volumeUsd24Hr { get; set; }
        public string priceUsd { get; set; }
        public string volumePercent { get; set; }
    }
}

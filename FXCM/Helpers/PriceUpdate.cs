using System;

namespace FXCM.Helpers
{
    public class PriceUpdate
    {
        public DateTime TradeDateTime { get; set; }
        public string Symbol { get; set; }
        public double Price { get; set; }
        public double PrevPrice { get; set; }
        public long Volume { get; set; }
        public double Bid { get; set; }
        public double Ask { get; set; }
        public double Low { get; set; }
        public double High { get; set; }
    }
}

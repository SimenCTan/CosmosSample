namespace CosmosSample_AzFunctions.ViewModels
{
    public class DailyQuoteViewModel
    {
        /// <summary>
        /// 营业日
        /// </summary>
        public int TradeDay { get; set; }

        /// <summary>
        /// 开盘价
        /// </summary>
        public decimal Open { get; set; }

        /// <summary>
        /// 最高价
        /// </summary>
        public decimal High { get; set; }

        /// <summary>
        /// 最低价
        /// </summary>
        public decimal Low { get; set; }

        /// <summary>
        /// 收盘价
        /// </summary>
        public decimal Close { get; set; }

        /// <summary>
        /// 交易量
        /// </summary>
        public double Volume { get; set; }


    }
}

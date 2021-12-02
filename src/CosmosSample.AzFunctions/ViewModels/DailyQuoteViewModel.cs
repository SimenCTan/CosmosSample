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
        public decimal OpenPrice { get; set; }

        /// <summary>
        /// 收盘价
        /// </summary>
        public decimal ClosePrice { get; set; }

        /// <summary>
        /// 交易量
        /// </summary>
        public double Volume { get; set; }
    }
}

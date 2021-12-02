namespace CosmosSample.Domain.Entities
{
    public class DailyQuote
    {
        /// <summary>
        /// TS代码
        /// </summary>
        public string TSCode { get; set; } = string.Empty;

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
        /// 昨收价
        /// </summary>
        public decimal PreClose { get; set; }

        /// <summary>
        /// 涨跌额
        /// </summary>
        public double Change { get; set; }

        /// <summary>
        /// 交易量
        /// </summary>
        public double Volume { get; set; }

        /// <summary>
        /// 成交额(千元)
        /// </summary>
        public decimal Amount { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using CosmosSample.Domain.Entities.Abstract;

namespace CosmosSample.Domain.Entities
{
    public class SymbolEntity : EntityBase
    {
        /// <summary>
        /// TS代码
        /// </summary>
        public string TSCode { get; set; } = string.Empty;

        /// <summary>
        /// 股票代码
        /// </summary>
        [StringLength(20)]
        public string Symbol { get; set; } = default!;

        /// <summary>
        /// 股票名称
        /// </summary>
        [StringLength(32)]
        public string Name { get; set; } = default!;

        public string Area { get; set; } = default!;

        /// <summary>
        /// 所属行业
        /// </summary>
        public string Industry { get; set; } = default!;

        /// <summary>
        /// 市场类型
        /// </summary>
        public string Market { get; set; } = default!;

        /// <summary>
        /// 交易所代码
        /// </summary>
        public string Exchange { get; set; } = default!;

        /// <summary>
        /// 交易货币
        /// </summary>
        public string Currency { get; set; } = default!;

        /// <summary>
        /// 上市状态
        /// </summary>
        public SymbolStatus SymbolStatus { get; set; }

        /// <summary>
        /// 上市日期
        /// </summary>
        public int ListDay { get; set; }

        /// <summary>
        /// 退市日期
        /// </summary>
        public int? DelistDay { get; set; }

        /// <summary>
        /// 日线行情
        /// </summary>
        public IList<DailyQuote> DailyQuotes { get; set; } = new List<DailyQuote>();

        /// <summary>
        /// Gets the hash code.
        /// </summary>
        /// <returns>The hash code of the document identifier.</returns>
        public override int GetHashCode() => Id.GetHashCode();

        /// <summary>
        /// Implements equality.
        /// </summary>
        /// <param name="obj">The object to compare to.</param>
        /// <returns>A value indicating whether the unique identifiers match.</returns>
        public override bool Equals(object? obj) => obj is SymbolEntity ds && ds.Symbol == Symbol && ds.Exchange == Exchange;

        /// <summary>
        /// Gets the string representation.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString() => $"symbol fullname {Name}";
    }

    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosSample.Domain.Entities
{
    /// <summary>
    /// 上市状态
    /// </summary>
    public enum SymbolStatus : byte
    {
        /// <summary>
        /// 上市
        /// </summary>
        List = 1,

        /// <summary>
        /// 停牌
        /// </summary>
        Pause,

        /// <summary>
        /// 退市
        /// </summary>
        Delist,
    }
}

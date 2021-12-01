using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosSample.Domain.Models
{
    /// <summary>
    /// Http response result with status code and response data.
    /// </summary>
    /// <typeparam name="TData">The type of response data.</typeparam>
    public class ResponseResult<TData> : StatusResponseResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseResult{T}"/> class.
        /// </summary>
        public ResponseResult()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseResult{T}"/> class.
        /// </summary>
        /// <param name="data">Response data.</param>
        public ResponseResult(TData data)
        {
            Data = data;
        }

        /// <summary>
        /// Gets or sets response data.
        /// </summary>
        public TData Data { get; set; } = default!;
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosSample.Domain.Models
{
    public class StatusResponseResult
    {
        /// <summary>
        /// Gets or sets response result status code.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Gets or sets response result message.
        /// </summary>
        public string? Message { get; set; }

    }
}

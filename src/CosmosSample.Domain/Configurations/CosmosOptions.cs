using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosSample.Domain.Configurations
{
    public class CosmosOptions
    {
        /// <summary>
        /// Gets or sets the endpoint.
        /// </summary>
        public string EndPoint { get; set; } = default!;

        /// <summary>
        /// Gets or sets the access key.
        /// </summary>
        public string AccessKey { get; set; } = default!;

        /// <summary>
        /// database name
        /// </summary>
        public string DatabaseName { get; set; } = default!;
    }
}

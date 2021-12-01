using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosSample.Domain.Entities.Abstract
{
    public abstract class EntityBase : EntityBaseWithTypedId<string>
    {
        /// <summary>
        /// Soft delete
        /// </summary>
        public bool Deleted { get; set; } = false;

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset? UpdatedOn { get;set; }
    }
}

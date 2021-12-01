using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CosmosSample.Domain.Entities.Abstract
{
    /// <summary>
    /// ValidationException
    /// </summary>
    public class ValidationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="validationResults"></param>
        public ValidationException(Type target, IList<ValidationResult> validationResults)
        {
            TargetType = target;
            ValidationResults = validationResults;
        }

        /// <summary>
        /// ValidationResults
        /// </summary>
        public IList<ValidationResult> ValidationResults { get; }

        /// <summary>
        /// TargetType
        /// </summary>
        public Type TargetType { get; }

        /// <summary>
        /// Message
        /// </summary>
        public override string Message
        {
            get
            {
                return string.Concat(TargetType.ToString(), ": ", string.Join(";", ValidationResults.Select(x => $"{x.ErrorMessage}")));
            }
        }
    }
}

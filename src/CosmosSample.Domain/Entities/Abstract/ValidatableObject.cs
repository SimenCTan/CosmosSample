using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CosmosSample.Domain.Entities.Abstract
{
    /// <summary>
    /// Validatable object.
    /// </summary>
    public abstract class ValidatableObject
    {
        /// <summary>
        /// Is valid.
        /// </summary>
        /// <returns>Whether object is valid.</returns>
        public virtual bool IsValid()
        {
            return Validate().Count == 0;
        }

        /// <summary>
        /// Validate object.
        /// </summary>
        /// <returns>List of <see cref="ValidationResult"/>.</returns>
        public virtual IList<ValidationResult> Validate()
        {
            IList<ValidationResult> validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(this, new ValidationContext(this, null, null), validationResults, true);
            return validationResults;
        }
    }
}

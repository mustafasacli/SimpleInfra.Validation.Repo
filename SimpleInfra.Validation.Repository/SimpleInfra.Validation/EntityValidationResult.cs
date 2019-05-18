namespace SimpleInfra.Validation
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// EntityValidationResult class.
    /// </summary>
    public class EntityValidationResult
    {
        /// <summary>
        /// Creates EntityValidationResult instance with validation errors.
        /// </summary>
        /// <param name="errors">Validation Errors</param>
        public EntityValidationResult(IList<ValidationResult> errors = null)
        {
            Errors = errors ?? new List<ValidationResult>();
        }

        /// <summary>
        /// Gets Validation Errors.
        /// </summary>
        public IList<ValidationResult> Errors { get; private set; }

        /// <summary>
        /// Gets Has Error.
        /// </summary>
        public bool HasError
        {
            get
            {
                return Errors.Count > 0;
            }
        }
    }
}
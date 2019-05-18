namespace SimpleInfra.Validation
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// ValidationExtension class
    /// </summary>
    public static class ValidationExtension
    {
        /// <summary>
        /// Validate an Entity.
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <param name="entity">Entity instance</param>
        /// <returns>Returns an EntityValidationResult instance.</returns>
        public static EntityValidationResult Validate<T>(this T entity) where T : class
        {
            var validationResults = new List<ValidationResult>();
            var vc = new ValidationContext(entity, null, null);
            var isValid = Validator.TryValidateObject
                    (entity, vc, validationResults, true);

            return new EntityValidationResult(validationResults);
        }
    }
}
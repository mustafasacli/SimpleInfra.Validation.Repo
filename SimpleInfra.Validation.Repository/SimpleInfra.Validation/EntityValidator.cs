namespace SimpleInfra.Validation
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// EntityValidator class
    /// </summary>
    /// <typeparam name="T">Entity Type</typeparam>
    public class EntityValidator<T> where T : class
    {
        /// <summary>
        ///  Validate an Entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Reurns an EntityValidationResult instance.</returns>
        public EntityValidationResult Validate(T entity)
        {
            var validationResults = new List<ValidationResult>();
            var vc = new ValidationContext(entity, null, null);
            var isValid = Validator.TryValidateObject
                    (entity, vc, validationResults, true);

            return new EntityValidationResult(validationResults);
        }
    }
}
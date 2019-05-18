namespace SimpleInfra.Validation
{
    /// <summary>
    /// ValidationHelper class
    /// </summary>
    public class ValidationHelper
    {
        /// <summary>
        /// Validates object.
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <param name="entity">Entity instance</param>
        /// <returns>returns an EntityValidationResult instance.</returns>
        public static EntityValidationResult ValidateEntity<T>(T entity)
            where T : class
        {
            return new EntityValidator<T>().Validate(entity);
        }
    }
}
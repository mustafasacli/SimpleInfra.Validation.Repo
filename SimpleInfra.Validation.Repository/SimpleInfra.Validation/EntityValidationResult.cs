namespace SimpleInfra.Validation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

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
            BuildErrorMessages();
            BuildDevErrorMessages();
        }

        private void BuildErrorMessages()
        {
            try
            {
                this.ValidationMessages = new List<string>();
                this.AllValidationMessages = string.Empty;

                if (this.HasError)
                {
                    this.ValidationMessages = this.Errors
                        .Select(q => q.ErrorMessage)
                     .ToList() ?? new List<string>();

                    this.AllValidationMessages = string.Join(" \r\n", ValidationMessages.ToArray()) ?? string.Empty;
                }
            }
            catch (Exception e)
            {
            }
        }

        private void BuildDevErrorMessages()
        {
            try
            {
                this.AllDevValidationMessages = string.Empty;

                if (this.HasError)
                {
                    var list = new List<string>();
                    list = this.Errors
                         .Select(q =>
                      {
                          var r = string.Join(":", q.MemberNames.ToArray());
                          return string.Format("{0};{1}", r, q.ErrorMessage);
                      })
                      .ToList() ?? new List<string>();

                    this.AllDevValidationMessages = string.Join(" ??", list.ToArray()) ?? string.Empty;
                }
            }
            catch (Exception e)
            {
            }
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

        /// <summary>
        /// Gets Validation Error Messages.
        /// </summary>
        public IList<string> ValidationMessages
        { get; private set; }

        /// <summary>
        /// Gets All Validation Error Messages.
        /// </summary>
        public string AllValidationMessages
        { get; private set; }

        /// <summary>
        /// Gets All Validation Error Messages.
        /// </summary>
        public string AllDevValidationMessages
        { get; private set; }
    }
}
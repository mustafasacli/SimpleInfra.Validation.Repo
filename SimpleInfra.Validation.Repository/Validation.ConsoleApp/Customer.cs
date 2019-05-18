using System.ComponentModel.DataAnnotations;

namespace Validation.ConsoleApp
{
    public class Customer
    {
        [Required]
        public virtual string CustomerID { get; set; }

        [Required]
        [StringLength(15)]
        public virtual string CompanyName { get; set; }

        public virtual string Address { get; set; }

        public virtual string City { get; set; }

        public virtual string PostalCode { get; set; }

        [Country(AllowCountry = "USA")]
        public virtual string Country { get; set; }

        [Phone]
        [Display(Name = "Telefon")]
        [Required(ErrorMessage = "Telefon giriniz.")]
        public virtual string Phone { get; set; }
    }
}

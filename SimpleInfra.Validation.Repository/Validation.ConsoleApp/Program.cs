namespace Validation.ConsoleApp
{
    using SimpleInfra.Validation;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Program Started.");
            // Arrange
            Customer customer = new Customer();
            //customer.CustomerID = "aaa";
            customer.CompanyName = "AAA companyıyportırptyportypoırpotyprotyopı";

            // Act
            var validationResult = customer.Validate(); // ValidationHelper.ValidateEntity<Customer>(customer);
            if (validationResult.HasError)
            {
                Console.WriteLine("Entity Has Error.");

                IList<ValidationResult> errors = validationResult.Errors;

                foreach (var err in errors)
                {
                    Console.WriteLine("Error : " + err.ErrorMessage);
                    foreach (var member in err.MemberNames)
                    {
                        Console.WriteLine("Member: " + member);
                    }
                    Console.WriteLine("--------------------------------------");
                }

                Console.WriteLine(validationResult.AllValidationMessages);
                Console.WriteLine("--------------------------------------");
                Console.WriteLine(validationResult.AllDevValidationMessages);
            }

            Console.WriteLine("Program Finished.");
            //var isValid = Validator.TryValidateObject(entity, vc, validationResults, true);

            Console.ReadKey();
        }
    }
}
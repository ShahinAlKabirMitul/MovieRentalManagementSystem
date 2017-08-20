using System;
using System.ComponentModel.DataAnnotations;

namespace MovieRentalManagementSystem.Models
{
    public class Min18YearsIfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == 1)
            {
                return ValidationResult.Success;
            }
            if (customer.BirthDay == null)
            {
                return new ValidationResult("Bith day is required");
            }
            var age = DateTime.Today.Year - customer.BirthDay.Value.Year;
            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 18 years to go on a membership");
        }
    }
}
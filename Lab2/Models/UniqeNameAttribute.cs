using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models
{
    public class UniqeNameAttribute : ValidationAttribute
    {
        public Mydb mydb = new Mydb();

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string name = value.ToString();
            int id = ((Course)validationContext.ObjectInstance).id;
            Course course= mydb.Courses.FirstOrDefault(c => c.name == name && c.id != id);
            if (course != null)
            {
                return new ValidationResult("Not Uniqe");

            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}

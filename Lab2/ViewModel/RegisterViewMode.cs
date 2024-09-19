using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab2.ViewModel
{
    public class RegisterViewMode
    {
        public string UserName {  get; set; }
        public string Email {  get; set; }

        [DataType(DataType.Password)]
        public string Password {  get; set; }

        [Compare("Password")]
        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword {  get; set; }


        public string Address { get; set; }

    }
}

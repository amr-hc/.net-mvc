using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab2.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email Is Required")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Remeber Me")]
        public bool RemeberMe { get; set; }
    }
}

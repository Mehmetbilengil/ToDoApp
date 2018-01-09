using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [StringLength(50, ErrorMessage = "Email must be maximum 50 characters long.")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First name")]
        [StringLength(40, ErrorMessage = "FirstName must be maximum 40 characters long.")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        [StringLength(40, ErrorMessage = "LastName must be maximum 40 characters long.")]
        public string LastName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }


   
    public class LoginResult:BaseResult
    {
      
        public string LastName { get; set; }
        public Guid Id { get; set; }

    


    }
}
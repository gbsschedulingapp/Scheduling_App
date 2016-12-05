using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Scheduling_App.ViewModels
{
    public class LoginVM
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter your Email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter your Password")]
        public string Password { get; set; }

        [Display(Name = "Keep me logged in?")]
        public bool KeepMeLoggedIn { get; set; }
    }
}
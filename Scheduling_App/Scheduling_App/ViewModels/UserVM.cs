using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Scheduling_App.ViewModels
{
    public class UserVM
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "UserName is required")]
        [StringLength(150)]
        [Display(Name = "UserName(Alias): ")]
        public string username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        [StringLength(150)]
        [Display(Name = "Email Address: ")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email is is not valid.")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(150, MinimumLength = 6)]
        [Display(Name = "Password: ")]
        public string password { get; set; }
        //public string PasswordSalt { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(150)]
        [Display(Name = "First Name: ")]
        public string first_name { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(150)]
        [Display(Name = "Last Name: ")]
        public string last_name { get; set; }

        [Display(Name = "Phone")]
        [StringLength(150)]
        public string phone { get; set; }

        [Display(Name = "Country")]
        [StringLength(150)]
        public string country { get; set; }

        [Display(Name = "Website")]
        [StringLength(150)]
        public string website { get; set; }

        [Display(Name = "Address 1")]
        [StringLength(150)]
        public string address_1 { get; set; }

        [Display(Name = "Address 2")]
        [StringLength(150)]
        public string address_2 { get; set; }

        [Display(Name = "State")]
        [StringLength(150)]
        public string state { get; set; }

        [Display(Name = "Zip")]
        public int? zip { get; set; }
        public enum user_type { is_admin, is_staff, is_student }

        [Display(Name = "Monday")]
        public int monday_to { get; set; }
        public int monday_from { get; set; }

        [Display(Name = "Tuesday")]
        public int tuesdday_to { get; set; }
        public int tuesday_from { get; set; }

        [Display(Name = "Wednesday")]
        public int wednesday_to { get; set; }
        public int wednesday_from { get; set; }

        [Display(Name = "Thursday")]
        public int thursday_to { get; set; }
        public int thursday_from { get; set; }

        [Display(Name = "Friday")]
        public int friday_to { get; set; }
        public int firday_from { get; set; }

        [Display(Name = "Saturday")]
        public int saturday_to { get; set; }
        public int saturday_from { get; set; }

        [Display(Name = "Sunday")]
        public int sunday_to { get; set; }
        public int sunday_from { get; set; }



    }
}
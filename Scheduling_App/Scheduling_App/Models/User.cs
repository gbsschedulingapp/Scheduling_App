using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduling_App.Models
{
    public class User
    {
        public int ID { get; set; }
        
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

        [Required(ErrorMessage = "Phone number is required")]
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
        public int zip { get; set; }

        public enum user_type { is_admin, is_staff, is_student }

        public Nullable<DateTime> CreatedOn { get; set; }

        public int RoleID { get; set; }

        [NotMapped]
        [Display(Name = "Service Name")]
        public string service_name { get; set; }

        [NotMapped]
        [Display(Name = "Appointment Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> appointment_date { get; set; }

        [NotMapped]
        [Display(Name = "Appointment Time")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> appointment_time { get; set; }

        [NotMapped]
        public string appointment_details { get; set; }

        [NotMapped]
        [Display(Name = "To Email")]        
        public string to_email { get; set; }

        [NotMapped]
        [Display(Name = "To First Name")]
        public string to_first_name { get; set; }

        [NotMapped]
        [Display(Name = "To Last Name")]
        public string to_last_name { get; set; }

    }
}
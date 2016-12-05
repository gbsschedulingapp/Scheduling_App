using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Scheduling_App.Models
{
    public class Appointment
    {
        public int ID { get; set; }
        [Display(Name = "Appointment Description")]
        public string appointment_details { get; set; }
		public int UserID { get; set; }
		public int UserServicesID { get; set; }
        public int AppointmentID_to { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> appointment_date { get; set; }

        [Display(Name = "Time")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> appointment_time { get; set; }


        //Create Appointment Form fields which are not included in database
        [NotMapped]
        [Display(Name = "Services")]
        public SelectList ServicesList { get; set; }
        //Appointment Create (Customers Form Fields)	
        [NotMapped]
        [Display(Name = "First Name")]
        public string first_name { get; set; }
        [NotMapped]
        [Display(Name = "Last Name")]
        public string last_name { get; set; }
        [NotMapped]
        [Display(Name = "Email")]
        public string email { get; set; }
        [NotMapped]
        [Display(Name = "Services")]
        public string phone { get; set; }

    }
}
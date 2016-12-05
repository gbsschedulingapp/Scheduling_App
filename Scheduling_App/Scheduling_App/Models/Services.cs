using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduling_App.Models
{
    public class Services
    {

        public int ID { get; set; }
        [Display(Name = "Service Name")]
        [Required(ErrorMessage = "Service Name is required")]
        public string service_name { get; set; }
        [Display(Name = "Duration")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime duration { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string service_details { get; set; }
        [Display(Name = "Cost")]
        public float cost { get; set; }
        [Display(Name = "Select User Name")]
        [Required(ErrorMessage = "Please Select user")]
        public int  UserID { get; set; }

        [NotMapped]
        public SelectList UserList { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Scheduling_App.ViewModels
{
    public class ServicesVM
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Service Name is required")]
        public string service_name { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public int duration { get; set; }
        [DataType(DataType.MultilineText)]
        public string service_details { get; set; }
        public string cost { get; set; }
    }
}
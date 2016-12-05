using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scheduling_App.Models
{
    public class TimeSlots
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string day { get; set; }
        public Nullable<System.TimeSpan> available_from { get; set; }
        public Nullable<System.TimeSpan> available_to { get; set; }
        public bool is_holiday { get; set; }
    }
}
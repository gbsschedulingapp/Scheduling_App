using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scheduling_App.ViewModels
{
    public class TimeSlotsVM
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string day;
        public Nullable<System.TimeSpan> available_from { get; set; }
        public Nullable<System.TimeSpan> available_to { get; set; }
        public bool is_holiday { get; set; }
    }
}
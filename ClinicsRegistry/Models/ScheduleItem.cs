using System;
using System.Collections.Generic;

namespace ClinicsRegistry.Models
{
    public class ScheduleItem
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ClientCard Client { get; set; }
        public Disease Diagnosis { get; set; }
    }

    public class ScheduleItemViewModel
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Patient { get; set; }
    }
}
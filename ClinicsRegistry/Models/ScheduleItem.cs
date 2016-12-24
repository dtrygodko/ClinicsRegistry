using System;
using System.ComponentModel;

namespace ClinicsRegistry.Models
{
    public class ScheduleItem
    {
        public Guid Id { get; set; }

        [DisplayName("Start date")]
        public DateTime StartDate { get; set; }

        [DisplayName("End date")]
        public DateTime EndDate { get; set; }

        public ClientCard Client { get; set; }

        public Disease Diagnosis { get; set; }
    }

    public class ScheduleItemViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Start date")]
        public DateTime StartDate { get; set; }

        [DisplayName("End date")]
        public DateTime EndDate { get; set; }

        public string Patient { get; set; }
    }
}
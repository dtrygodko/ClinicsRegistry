using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ClinicsRegistry.Models
{
    public class ClientCard
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        [DisplayName("Birth date")]
        public DateTime BirthDate { get; set; }

        [DisplayName("Is employee")]
        public bool IsEmployee { get; set; }

        public virtual List<ScheduleItem> Visits { get; set; } = new List<ScheduleItem>();
    }
}
using System;
using System.Collections.Generic;

namespace ClinicsRegistry.Models
{
    public class ClientCard
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsEmployee { get; set; }
        public virtual List<ScheduleItem> Visits { get; set; } = new List<ScheduleItem>();
    }
}
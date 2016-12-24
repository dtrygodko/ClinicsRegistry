using System;
using System.Collections.Generic;

namespace ClinicsRegistry.Models
{
    public class Disease
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Symptom> Symptoms { get; set; } = new List<Symptom>();

        public List<ScheduleItem> Visits { get; set; } = new List<ScheduleItem>();
    }
}
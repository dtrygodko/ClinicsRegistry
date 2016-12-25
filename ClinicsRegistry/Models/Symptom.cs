using System;
using System.Collections.Generic;

namespace ClinicsRegistry.Models
{
    public class Symptom
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<Disease> Diseases { get; set; } = new List<Disease>();
    }
}
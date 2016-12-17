using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicsRegistry.Models
{
    public class ScheduleItem
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ClientCard Client { get; set; }
    }
}
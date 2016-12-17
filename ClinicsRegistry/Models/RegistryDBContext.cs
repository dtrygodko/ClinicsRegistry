using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ClinicsRegistry.Models
{
    public class RegistryDBContext : DbContext
    {
        public DbSet<ScheduleItem> Visits { get; set; }
        public DbSet<ClientCard> Cards { get; set; }
    }
}
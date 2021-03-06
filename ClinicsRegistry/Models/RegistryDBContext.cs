﻿using System.Data.Entity;

namespace ClinicsRegistry.Models
{
    public class RegistryDBContext : DbContext
    {
        public DbSet<ScheduleItem> Visits { get; set; }
        public DbSet<ClientCard> Cards { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Symptom> Symptoms { get; set; }
    }
}
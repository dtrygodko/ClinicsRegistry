using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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

        public int Price { get; private set; }

        public void SetPrice()
        {
            if (Client.IsEmployee)
            {
                Price = 0;
            }
            else
            {
                TimeSpan span = EndDate - StartDate;
                Price = (int)span.TotalMinutes;
            }
        }
    }

    public class ScheduleItemViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Start date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DisplayName("End date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public ClientCard Client { get; set; }

        public List<SelectListItem> Patients { get; set; }

        public Disease Diagnosis { get; set; }

        public List<SelectListItem> Diagnoses { get; set; }

        public string Patient { get; set; }

        public int Price { get; set; }
    }
}
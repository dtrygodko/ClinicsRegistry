using System.Collections.Generic;
using System.Web.Mvc;

namespace ClinicsRegistry.Models
{
    public class DiseasesSymptomsViewModel
    {
        public Disease Disease { get; set; }

        public List<SelectListItem> Diseases { get; set; }

        public Symptom Symptom { get; set; }

        public List<SelectListItem> Symptoms { get; set; }
    }
}
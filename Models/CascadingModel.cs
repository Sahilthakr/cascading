using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cascading.Models
{
    public class CascadingModel
    {
        public CascadingModel()
        {
            this.Country = new List<SelectListItem>();
            this.State = new List<SelectListItem>();
            this.City = new List<SelectListItem>();
        }

        public List<SelectListItem> Country { get; set; }
        public List<SelectListItem> State { get; set; }
        public List<SelectListItem> City { get; set; }

        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
    }
}

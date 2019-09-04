using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVS362.PropertyHub.WebUI.Models
{
    public class NeighborhoodModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CityModel City { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVS362.PropertyHub.WebUI.Models
{
    public class CityModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ProvinceModel Province { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVS360.PropertyHub
{
    public class PropertyImage 
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Caption { get; set; }

        [Required]
        [Column(TypeName = "varchar(300)")]
        public string ImageUrl { get; set; }

        public int Priority { get; set; }


    }
}

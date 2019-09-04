using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVS360.PropertyHub
{
    public class PropertyFeature : IListable
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(300)")]
        public string Name { get; set; }
    }
}

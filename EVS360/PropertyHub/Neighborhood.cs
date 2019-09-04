using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVS360.PropertyHub
{
    public class Neighborhood : IListable
    {
        public Neighborhood()
        {
            Blocks = new List<NeighborhoodBlock>();
        }

        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        public virtual ICollection<NeighborhoodBlock> Blocks { get; set; }

        public virtual City City { get; set; }

    }
}

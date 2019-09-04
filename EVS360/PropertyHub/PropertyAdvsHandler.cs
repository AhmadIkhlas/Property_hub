using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EVS360.PropertyHub
{
    public class PropertyAdvsHandler
    {

        public List<Neighborhood> GetNeighborhoods()
        {
            using (PropertyHubContext context=new PropertyHubContext())
            {
                return (from c in context.HousingSchemes
                        .Include(c => c.City)
                        select c).ToList();
            }
        }


      


        public Neighborhood GetNeighborhood(int id)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from c in context.HousingSchemes
                        .Include(c=>c.City)
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }

        public Neighborhood AddNeighborhood(Neighborhood neighborhood)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                context.Entry(neighborhood.City).State = EntityState.Unchanged;
                context.Add(neighborhood);
                context.SaveChanges();
            }
            return neighborhood;
        }

        public Neighborhood DeleteNeighborhood(int id)
        {
            Neighborhood found = null;
            using (PropertyHubContext context = new PropertyHubContext())
            {
                found = context.HousingSchemes.Find(id);
                context.Remove(found);
                context.SaveChanges();
            }
            return found;
        }

        public Neighborhood UpdateNeighborhood(int idToSearch,Neighborhood neighborhood)
        {
            Neighborhood found = null;
            using (PropertyHubContext context = new PropertyHubContext())
            {
                found = context.HousingSchemes.Find(idToSearch);
                if (!string.IsNullOrEmpty(neighborhood.Name))
                {
                    found.Name = neighborhood.Name;
                }
                if (neighborhood.City?.Id != 0)
                {
                    found.City = neighborhood.City;
                }
                if (neighborhood.Blocks != null)
                {
                    found.Blocks = neighborhood.Blocks;
                }
                context.Entry(found.City).State = EntityState.Unchanged;
                context.SaveChanges();
            }
            return neighborhood;
        }



    }
}

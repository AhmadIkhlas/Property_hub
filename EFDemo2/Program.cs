using EVS360;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace EFDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (PropertyHubContext context=new PropertyHubContext()) 
            //{
            //    //Create
            //    //context.Add(new Country { Code = 92, Name = "Pakistan" });
            //    //context.Add(new Country { Code = 1, Name = "USA" });
            //    //context.Add(new Country { Code = 86, Name = "China" });
            //    //context.SaveChanges();

            //    //Retrieve
            //    //Country c = (from c in context.Countries where c.Id == 1 select c).FirstOrDefault();
            //    //List<Country> result = (from c in context.Countries select c).ToList();
            //    //List<Country> result = (from c in context.Countries where c.Code < 100 select c).ToList();
            //    //List<Country> result = context.Countries.ToList();
            //    //Country found = context.Find<Country>(1);

            //    //Update
            //    //Country found = context.Find<Country>(1);
            //    //found.Name = "New Name";
            //    //found.Code = 111;
            //    //context.SaveChanges();

            //    //Delete
            //    //Country found = context.Find<Country>(1);
            //    //context.Remove(found);
            //    //context.SaveChanges();

            //    //var result = from c in context.Countries select c;
            //    //foreach (var r in result)
            //    //{
            //    //    Console.WriteLine($"{r.Code}\t{r.Name}");
            //    //}

            //    Province p = new Province();
            //    p.Name = "Punjab";
            //    p.Cities.Add(new City { Name = "Lahore" });
            //    p.Cities.Add(new City { Name = "Faisalabad" });
            //    p.Country = context.Find<Country>(4);
            //    //p.Country = new Country { Id = 4 };
            //    //context.Entry(p.Country).State = EntityState.Unchanged;
            //    context.Add(p);
            //    context.SaveChanges();

            //}


            LocationsHandler temp = new LocationsHandler();
            Country pk = new Country { Id = 4 };
            temp.AddProvince(new Province { Name = "Sindh", Country = pk });
            temp.AddProvince(new Province { Name = "KPK", Country = pk });
            temp.AddProvince(new Province { Name = "Baluchistan", Country = pk });

            List<Province> provinces = temp.GetProvinces();
            foreach (var p in provinces)
            {
                Console.WriteLine(p.Name);
            }

            Console.WriteLine("Done.");
            Console.ReadKey();

        }
    }
}

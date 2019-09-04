using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EVS360
{
    public class LocationsHandler
    {
        //Country
        public Country AddCountry(Country entity)
        {
            using (PropertyHubContext context=new PropertyHubContext())
            {
                context.Add(entity);
                context.SaveChanges();
            }
            return entity;
        }
        public Country DeleteCountry(int idToSearch)
        {
            Country found = null;
            using (PropertyHubContext context = new PropertyHubContext())
            {
                found = context.Find<Country>(idToSearch);
                context.Remove(found);
                context.SaveChanges();
            }
            return found;
        }
        public Country UpdateCountry(int idToSearch,Country entity)
        {
            Country found = null;
            using (PropertyHubContext context = new PropertyHubContext())
            {
                found = context.Find<Country>(idToSearch);
                if (entity.Code.HasValue && entity.Code!=0)
                {
                    found.Code = entity.Code;
                }
                if (!string.IsNullOrEmpty(entity.Name))
                {
                    found.Name = entity.Name;
                }                
                context.SaveChanges();
            }
            return entity;
        }
        public List<Country> GetCountries()
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from c in context.Countries
                       select c).ToList();
            }
        }
        public Country GetCountries(int id)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from c in context.Countries
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }

               //City
        public City GetCities(int id)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from c in context.Cities
                        .Include(c=>c.Province)
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }
        public List<City> GetCities(Country country)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from c in context.Cities
                        .Include(c=>c.Province.Country)
                        where c.Province.Country.Id == country.Id
                        select c).ToList();
            }
        }
        public List<City> GetCities()
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from c in context.Cities
                        select c).ToList();
            }
        }
        public City AddCity(City entity)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                context.Entry(entity.Province).State = EntityState.Unchanged;
                context.Add(entity);
                context.SaveChanges();
            }
            return entity;
        }
        public City UpdateCity(int idToSearch, City neighborhood)
        {
            City found = null;
            using (PropertyHubContext context = new PropertyHubContext())
            {
                found = context.Cities.Find(idToSearch);
                if (!string.IsNullOrEmpty(neighborhood.Name))
                {
                    found.Name = neighborhood.Name;
                }
                if (neighborhood.Province?.Id != 0)
                {
                    found.Province = neighborhood.Province;
                }

                context.Entry(found.Province).State = EntityState.Unchanged;
                context.SaveChanges();
            }
            return neighborhood;
        }
        public City DeleteCities(int idToSearch)
        {
            City found = null;
            using (PropertyHubContext context = new PropertyHubContext())
            {
                found = context.Find<City>(idToSearch);
                context.Remove(found);
                context.SaveChanges();
            }
            return found;
        }

        //Province
        public Province AddProvince(Province entity)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                context.Entry(entity.Country).State = EntityState.Unchanged;
                context.Add(entity);
                context.SaveChanges();
            }
            return entity;
        }
        public Province UpdateProvince(int idToSearch, Province entity)
        {
            Province found = null;
            using (PropertyHubContext context = new PropertyHubContext())
            {
                found = context.Provinces.Find(idToSearch);
                if (!string.IsNullOrEmpty(entity.Name))
                {
                    found.Name = entity.Name;
                }
                if (entity.Country?.Id != 0)
                {
                    found.Country = entity.Country;
                }
               
                context.Entry(found.Country).State = EntityState.Unchanged;
                context.SaveChanges();
            }
            return found;
        }
//        Province found = null;
//            using (PropertyHubContext context = new PropertyHubContext())
//            {
//                found = context.Find<Province>(idToSearch);
//                found.Name = entity.Name;
//                if(entity.Country?.Id > 0)
//                {
//                    found.Country = entity.Country;
//                }
//context.SaveChanges();
//            }
//            return found;
      

        public Province DeleteProvince(int idToSearch)
        {
            Province found = null;
            using (PropertyHubContext context = new PropertyHubContext())
            {
                found = context.Find<Province>(idToSearch);
                context.Remove(found);
                context.SaveChanges();
            }
            return found;
        }
        public List<Province> GetProvinces()
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from c in context.Provinces
                        select c).ToList();
            }
        }
        public List<Province> GetProvinces(Country country)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from c in context.Provinces
                        .Include(c => c.Country)
                        select c).ToList();
            }
        }
        public Province GetProvince(int id)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from c in context.Provinces
                        .Include(c=>c.Country)
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }
    
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EVS360.UsersMgt
{
    public class UsersHandler
    {
        public List<User> GetUsers()
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from u in context.Users
                        .Include("Role")
                        .Include("Address.City.Province.Country")
                        select u).ToList();
            }
        }

        public User GetUser(string loginid, string password)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from u in context.Users
                        .Include("Role")
                        .Include("Address.City.Province.Country")
                        where u.LoginId.Equals(loginid) && u.Password.Equals(password)
                        select u).FirstOrDefault();
            }
        }


        public List<Role> GetRoles()
        {
            PropertyHubContext context = new PropertyHubContext();
            using (context)
            {
                return (from u in context.Roles
                        select u).ToList();
            }
        }

    }
}

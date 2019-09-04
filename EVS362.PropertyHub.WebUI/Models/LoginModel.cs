using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVS362.PropertyHub.WebUI.Models
{
    public class LoginModel
    {
        public string LoginId { get; set; }

        public string Password { get; set; }

        public bool RemeberMe { get; set; }

    }
}

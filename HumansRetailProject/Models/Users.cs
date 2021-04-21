using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HumansRetailProject.Models
{
    public class Users
    {
        public int id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string mail { get; set; }
        public string phone { get; set; }

    }
}
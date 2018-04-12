using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class UserAccess
    {
        public int id { get; set; }
        public string RoleName { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string MenuItem { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class RequestInfo
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string ReqDateTime { get; set; }
        public string UserName { get; set; }
        public bool Approved { get; set; }
    }
}
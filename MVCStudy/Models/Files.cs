using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCStudy.Models
{
    public class Files
    {
        public string FullName { get; set; }
        public string ModifiedTime { get; set; }
        public string Content { get; set; }
    }
}
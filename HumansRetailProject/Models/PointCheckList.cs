using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HumansRetailProject.Models
{
    public class PointCheckList
    {
        public int id { get; set; }
        public int PointID { get; set; }
        public string UserID { get; set; }
        public int PrinterSN { get; set; }
        public int RouterSN { get; set; }
        public string CheckDate { get; set; }
        public string Description { get; set; }
    }
}
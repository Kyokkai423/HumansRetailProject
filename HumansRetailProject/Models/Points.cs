using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HumansRetailProject.Models
{
    public class Points
    {
        public int id { get; set; }
        public int PointNumber { get; set; }
        public string PointName { get; set; }
        public string PointAddress { get; set; }
        public string PointType { get; set; }
        public string PointStatus { get; set; }
        public string PointLatitude { get; set; }
        public string PointLongitude { get; set; }
        public string PointworkTime { get; set; }
        public int ISPID { get; set; }
        public string ISPPointCost { get; set; }

    }
}
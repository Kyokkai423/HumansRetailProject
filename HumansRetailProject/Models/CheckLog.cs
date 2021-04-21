using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HumansRetailProject.Models
{
    public class CheckLog
    {
        public int Id { get; set; }
        public string CardPrinter { get; set; }
        public bool PrinterRibbon { get; set; }
        public bool PrinterCartridge { get; set; }
        public bool PrinterCleaning { get; set; }
        public bool PrinterCalibration { get; set; }
        public string RouterModel { get; set; }
        public string RouterSN { get; set; }
        public bool Modem4G { get; set; }
        public bool SimCard { get; set; }
        public int SimImsi { get; set; }
        public string SimOperator { get; set; }
        public bool PaymentTerminal { get; set; }
        public bool TerminalWires { get; set; }
        public string TerminalCondition { get; set; }
        public string InternetSpeed { get; set; }
        public string InternetProvider { get; set; }
        public string Dispenser { get; set; }
        public string UserId { get; set; }
        public int PointId { get; set; }
        public string CheckDate { get; set; }
    }
}
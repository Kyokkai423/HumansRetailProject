using HumansRetailProject.Models;
using HumansRetailProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HumansRetailProject.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db = new ApplicationContext();
        [Authorize]
        public ActionResult Index(string find)
        {
            IEnumerable <Points> points = db.Points;
            if (!String.IsNullOrEmpty(find))
            {
                points = points.Where(s => s.PointName.Contains(find));
            }
            ViewBag.Points = points;
            return View();
        }
        [HttpGet]
        public ActionResult Point(int PNumber)
        {
            ViewBag.CheckList = db.CheckLists.Where(x => x.PointID == PNumber);
            return View();
            
        }
        [HttpGet]
        public ActionResult Checklist()
        {
            ViewBag.CheckLog = db.CheckLists.ToList();
            List<string> routerModels = new List<string>() { "MikroTik", "Tp-Link" };
            List<string> simOperators = new List<string>() { "Humans", "Beeline" };
            List<string> terminalConditions = new List<string>() { "Работает", "Не работает" };
            ViewBag.RouterModels = routerModels.ToList();
            ViewBag.SimOperators = simOperators.ToList();
            ViewBag.TerminalConditions = terminalConditions.ToList();
            return View();            
        }
        [HttpPost]
        public ActionResult Checklist(CheckLog checkLog)
        {
            var pnumber = Convert.ToInt32(Request["PNumber"]);
            var user = HttpContext.User.Identity.Name;
            checkLog.CheckDate = DateTime.Now.ToString();
            checkLog.UserId = user;
            checkLog.PointId = pnumber;
            db.CheckLogs.Add(checkLog);

            if (db.CheckLists.Any(x => x.PointID == pnumber) == true)
            {
                var point = db.CheckLists
                    .Where(x => x.PointID == pnumber)
                    .FirstOrDefault();

                point.CheckDate = DateTime.Now.ToString();
                point.UserID = user;
            }
            else
            {
                var point = db.CheckLists;
                point.Add(new PointCheckList { PointID = pnumber, UserID = user, CheckDate = DateTime.Now.ToString() });
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }




























        //public ActionResult Checklist(int? PointID)
        //{
        //    if (PointID == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    if (db.CheckLists.Any(x => x.PointID == PointID) == false)
        //    {
        //        PointCheckList checkList = new PointCheckList() { PointID = Convert.ToInt32(PointID) };
        //        db.CheckLists.Add(checkList);
        //        db.SaveChanges();
        //        return View(checkList);
        //    }
        //    else
        //    {
        //        PointCheckList checkList = db.CheckLists.First(x => x.PointID == PointID);
        //        return View(checkList);
        //    }
        //}
        //[HttpPost]
        //public ActionResult Checklist(PointCheckList checkList)
        //{
        //    checkList.CheckDate = DateTime.Now.ToString();
        //    checkList.PointID = Convert.ToInt32(Request["PointID"].ToString());
        //    db.Entry(checkList).State = System.Data.Entity.EntityState.Modified;
        //    db.SaveChanges();

        //    return RedirectToAction("Index");
        //}
    }
}
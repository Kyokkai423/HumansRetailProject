using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HumansRetailProject.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                string Extension = System.IO.Path.GetExtension(upload.FileName);
                upload.SaveAs(Server.MapPath("~/Files/" + fileName));

                ImportToDatabase(Server.MapPath("~/Files/" + fileName), Extension, "Yes");
                
            }
            return RedirectToAction("Index");
        }
        protected void NewRecord(string PointNumber, string PointName, string PointAddress, string PointType, string PointStatus, string Pointlatitude, string PointLongitude, string PointworkTime)
        {
            try
            {
                SQLiteConnection con = new SQLiteConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into Points (PointNumber,PointName,PointAddress,PointType,PointStatus,Pointlatitude,PointLongitude,PointworkTime) values (" + PointNumber + ",'" + PointName + "','" + PointAddress.Replace("'", "") + "','" + PointType + "','" + PointStatus + "','" + Pointlatitude + "','" + PointLongitude + "','" + PointworkTime + "')";
                cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
            }
        }
        protected void ImportToDatabase(string FilePath, string Extension, string isHDR)
        {
            try
            {
                string conStr = "";

                switch (Extension)
                {
                    case ".xls": //Excel 97-03
                        conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                        break;
                    case ".xlsx": //Excel 07
                        conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                        break;
                }
                conStr = String.Format(conStr, FilePath, isHDR);
                OleDbConnection connExcel = new OleDbConnection(conStr);
                OleDbCommand cmdExcel = new OleDbCommand();
                OleDbDataAdapter oda = new OleDbDataAdapter();

                DataTable dt = new DataTable();

                cmdExcel.Connection = connExcel;
                connExcel.Open();
                DataTable dtExcelSchema;
                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string SheetName = dtExcelSchema.Rows[1]["TABLE_NAME"].ToString();
                connExcel.Close();

                connExcel.Open();
                cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
                oda.SelectCommand = cmdExcel;
                OleDbDataReader rdExcel = cmdExcel.ExecuteReader();
                while (rdExcel.Read())
                {
                    NewRecord(rdExcel[0].ToString(), rdExcel[1].ToString(), rdExcel[2].ToString(), rdExcel[3].ToString(), rdExcel[4].ToString(), rdExcel[5].ToString(), rdExcel[6].ToString(), rdExcel[7].ToString());
                }
                rdExcel.Close();
                connExcel.Close();
            }
            catch (Exception ex)
            {
            }

        }
    }
}
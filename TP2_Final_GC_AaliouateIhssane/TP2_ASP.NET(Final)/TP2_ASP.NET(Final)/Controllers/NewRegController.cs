using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP2_ASP.NET_Final_.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace TP2_ASP.NET_Final_.Controllers
{
    public class NewRegController : Controller
    {
        // GET: NewReg
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserClass uc,HttpPostedFileBase file)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "insert into register values(@UserName,@UserPassword,@job,@email,@Photo,getdate())";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlconn.Open();
            sqlcomm.Parameters.AddWithValue("@UserName", uc.UserName);
            sqlcomm.Parameters.AddWithValue("@UserPassword", uc.UserPassword);
            sqlcomm.Parameters.AddWithValue("@job", uc.job);
            sqlcomm.Parameters.AddWithValue("@email", uc.email);

            if (file!=null && file.ContentLength > 0)
            {
                string filename = Path.GetFileName(file.FileName);
                string imgpath = Path.Combine(Server.MapPath("~/User-images/"),filename);
                file.SaveAs(imgpath);
            }

            sqlcomm.Parameters.AddWithValue("@Photo", "~/User-images/"+file.FileName);

            sqlcomm.ExecuteNonQuery();
            sqlconn.Close();

            ViewData["Message"] = "User reccord " + uc.UserName + " is sevad successfully !";
            return View();
        }
    }
}
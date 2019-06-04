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
    public class NewMsgController : Controller
    {
        // GET: NewMsg
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(MessageClass mc)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "insert into Msg values(@Email,@UserName,@mssg,getdate())";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlconn.Open();
            sqlcomm.Parameters.AddWithValue("@Email", mc.Email);
            sqlcomm.Parameters.AddWithValue("@UserName", mc.UserName);
            sqlcomm.Parameters.AddWithValue("@mssg", mc.mssg);

            

            sqlcomm.ExecuteNonQuery();
            sqlconn.Close();

            ViewData["Message"] = "Message By " + mc.UserName + " is sevad successfully !";
            return View();
        }
    }
}
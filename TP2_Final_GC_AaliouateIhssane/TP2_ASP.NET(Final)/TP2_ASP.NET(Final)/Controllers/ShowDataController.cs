using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP2_ASP.NET_Final_.Models;
using TP2_ASP.NET_Final_.ViewModel;

namespace TP2_ASP.NET_Final_.Controllers
{
    public class ShowDataController : Controller
    {
        [Authorize]
        // GET: ShowData
        public ActionResult Multidata()
        {
            ViewData["uname"] = User.Identity.Name;

            TP2_dbEntities obj = new TP2_dbEntities();
            var mymodel = new Multipledata();
            mymodel.Msgsss = obj.Msgs.ToList();
            mymodel.registersss = obj.registers.ToList();


            return View(mymodel);
        }
    }
}
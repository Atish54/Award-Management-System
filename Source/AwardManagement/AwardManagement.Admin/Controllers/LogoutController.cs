using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AwardManagement.Admin.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Logout
        [Route("Logout")]
        public ActionResult Index()
        {
            //var data = Session ["UserName"];
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            string url = "";
            if (Session ["UserName"] == null && Session ["UserID"] == null)
            {
                HttpContext.Session.RemoveAll();
                url = "~/Login/Index";
            }
            return Redirect(url);
        }
    }
}
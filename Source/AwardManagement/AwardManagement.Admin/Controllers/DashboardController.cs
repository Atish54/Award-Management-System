using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AwardManagement.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
      
        public ActionResult Index()
        {
            if (Session ["UserName"] != null && Session ["UserID"] != null)
            {
                return View();
            }
            return RedirectToActionPermanent("Index", "Login");
        }
    }
}
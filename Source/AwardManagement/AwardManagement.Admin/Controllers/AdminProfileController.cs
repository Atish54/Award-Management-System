using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using AwardManagment.BusinessObjects.Model;

namespace AwardManagement.Admin.Controllers
{
    public class AdminProfileController : Controller
    {
        HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:62192/api/") };
        // GET: AdminProfile
     
        public ActionResult AdminProfile()
        {
            return View();
        }
    }
}
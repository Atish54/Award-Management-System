using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AwardManagment.BusinessObjects.Model;
using System.Net.Http;
using Newtonsoft.Json;

namespace AwardManagement.Admin.Controllers
{
    public class ApplicationController : Controller
    {
        HttpClient client = new HttpClient() { BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["WebServiceUrl"]) };

        private static List<BOApplication> Applst = new List<BOApplication>();
        // GET: Application
        public ActionResult ApplicationManage()
        {
           
            //var responseTask = client.GetAsync("User").Result;
            //Userlst = JsonConvert.DeserializeObject<List<BOUser>>(responseTask.Content.ReadAsStringAsync().Result);

            GetAppList();
            ViewBag.Data = Applst.Where(U => U.isRejected == false).OrderByDescending(U => U.isRejected).ToList();
            return View();
            
        
            
        }
        private bool GetAppList()
        {
            var responseTask = client.GetAsync("User").Result;
            Applst = JsonConvert.DeserializeObject<List<BOApplication>>(responseTask.Content.ReadAsStringAsync().Result);
            if (Applst.Count != 0)
            {
                return true;
            }
            return true;
        }
        public ActionResult ViewDetail()
        {
           return View();
           
        }
    }
}
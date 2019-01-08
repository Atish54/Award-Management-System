using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using AwardManagment.BusinessObjects.Model;
using Newtonsoft.Json;


namespace AwardManagement.Admin.Controllers
{
    public class LoginController : Controller
    {
        HttpClient client = new HttpClient() { BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings ["WebServiceUrl"]) };
        // private static List<BOUser> Userlst = new List<BOUser>();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> Login(FormCollection FC)
        {
            BOLogin BL = new BOLogin();
            BL.Email = FC ["Email"];
            BL.Password = FC ["Password"];

            try
            {
                var Response = await client.PostAsJsonAsync("Login", BL);
                if (Response.IsSuccessStatusCode)
                {
                    BOUser data = JsonConvert.DeserializeObject<BOUser>(Response.Content.ReadAsStringAsync().Result);
                    var d = data.UserRoles.Select(u => new BOUserRole
                    {
                        Role = new BORole
                        {
                            Role1 = u.Role.Role1,
                            RoleId = u.Role.RoleId,
                            IsDisable = u.Role.IsDisable
                        }
                    });
                    var b = d.Where(u => u.Role.Role1 == "Admin" && u.Role.IsDisable == false).Single();
                    if (b.IsDisable == false && b.Role.Role1 == "Admin")
                    {
                        Session ["UserName"] = data.Name;
                        Session ["UserEmail"] = FC ["Email"];
                        Session ["UserID"] = data.UserId;
                        return RedirectToAction("Index", "Dashboard");
                    }
                }
            }
            catch (Exception e) { Console.WriteLine("Login Error: " + e.ToString()); }
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
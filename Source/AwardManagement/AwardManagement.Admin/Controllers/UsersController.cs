using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AwardManagment.BusinessObjects.Model;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Formatting;
using System.Web.Script.Serialization;

namespace AwardManagement.Admin.Controllers
{
    public class UsersController : Controller
    {
        HttpClient client = new HttpClient() { BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings ["WebServiceUrl"]) };
        private static List<BOUser> Userlst = new List<BOUser>();


        public ActionResult AddUsers()
        {
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> AddUsers(FormCollection FC)
        {
            BOUser BOU = new BOUser();
            BOU.Name = FC ["Name"].Trim();
            BOU.Email = FC ["Email"].Trim();
            BOU.Password = FC ["Password"].Trim();
            BOU.Mobile = FC ["Mobile"].Trim();
            BOU.Gender = Convert.ToBoolean(FC ["userGender"]);
            BOU.DOJ = Convert.ToDateTime(FC ["DOJ"]);
            BOU.DOB = Convert.ToDateTime(FC ["DOB"]);
            BOU.Designation = FC ["Designation"].Trim();

            if (BOU.Name != "" && BOU.Email != "" && BOU.Password != "" && BOU.Mobile != "" && BOU.DOJ.ToString() != "" && BOU.DOB.ToString() != "" && BOU.Designation != "")
            {
                if (FC ["UserId"] != null)
                {

                    BOU.UserId = Guid.Parse(FC ["UserId"]);
                    var Response = await client.PutAsJsonAsync("User", BOU);

                    if (Response.IsSuccessStatusCode)
                    {
                        var Responsedata = Convert.ToBoolean(Response.Content.ReadAsStringAsync().Result);

                        if (Responsedata == true) { TempData ["UpdateSuccess"] = true; }
                        else { TempData ["UpdateSuccess"] = false; }
                    }
                    else
                    { ViewBag.UpdateSuccess = false; }
                }

                else
                {
                    var Response = await client.PostAsJsonAsync("User", BOU);
                    if (Response.IsSuccessStatusCode)
                    {
                        var Responsedata = Convert.ToBoolean(Response.Content.ReadAsStringAsync().Result);

                        if (Responsedata == true) { TempData ["InsertSuccess"] = true; }
                        else { TempData ["InsertSuccess"] = false; }

                    }
                    else { ViewBag.InsertSuccess = false; }
                }
            }
            else
            {
                TempData ["DataNull"] = true;
            }

            return RedirectToAction("AddUsers", "Users");
        }

        public ActionResult ManageUsers()
        {
            //var responseTask = client.GetAsync("User").Result;
            //Userlst = JsonConvert.DeserializeObject<List<BOUser>>(responseTask.Content.ReadAsStringAsync().Result);

            GetUsersList();
            ViewBag.Data = Userlst.Where(U => U.IsDisable == false).OrderByDescending(U => U.IsDisable).ToList();
            return View();
        }

        public async System.Threading.Tasks.Task<bool> CheckEmail(string email)
        {
            BOUser _user = new BOUser();
            _user.Email = email;
            var Response = await client.PostAsJsonAsync("User", _user);
            if (Response.IsSuccessStatusCode)
            {
                var Responsedata = Convert.ToBoolean(Response.Content.ReadAsStringAsync().Result);

                if (Responsedata == true)
                {
                    
                    return true;  //It Means Email is Existing
                }
            }
            return false;
        }

        private bool GetUsersList()
        {
            var responseTask = client.GetAsync("User").Result;
            Userlst = JsonConvert.DeserializeObject<List<BOUser>>(responseTask.Content.ReadAsStringAsync().Result);
            if (Userlst.Count != 0)
            {
                
                return true;
            }
            return true;
        }

        public ActionResult RemoveUser(Guid id)
        {
            BOUser BOU = new BOUser();
            BOU.UserId = id;
            var Response = client.DeleteAsync("User/" + BOU.UserId).Result;
            if (Response.IsSuccessStatusCode)
            {
                var Responsedata = Convert.ToBoolean(Response.Content.ReadAsStringAsync().Result);

                if (Responsedata == true)
                {
                    return RedirectToAction("ManageUsers", "Users");
                }
                else { TempData ["DeleteSuccess"] = false; }
            }
            else { Console.WriteLine("Fail"); }
            return null;
        }
    }
}
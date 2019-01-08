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
    public class NewsController : Controller
    {
        HttpClient client = new HttpClient() { BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings ["WebServiceUrl"]) };
        private static List<BONews> Newslst = new List<BONews>();


        public ActionResult ManageNews()
        {

            var responseTask = client.GetAsync("News").Result;
            Newslst = JsonConvert.DeserializeObject<List<BONews>>(responseTask.Content.ReadAsStringAsync().Result);
            ViewBag.Data = Newslst.Where(N => N.IsDisable == false).OrderByDescending(Q => Q.IsDisable).ToList();

            ViewBag.UpdateSuccess = TempData ["UpdateSuccess"]; // Send View to Update Sucess msg.
            ViewBag.InsertSuccess = TempData ["InsertSuccess"]; // Send View to Insert Sucess msg.
            ViewBag.InsertSuccess = TempData ["InsertSuccess"]; // Send View to Insert Fail msg.
            ViewBag.DataNull = TempData ["DataNull"]; // Send View to Error Sucess msg.
            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> InsertNews(FormCollection FC)
        {
            if (ModelState.IsValid)
            {
                BONews BON = new BONews();

                BON.News1 = FC ["News1"];

                if (BON.News1 != "")
                {
                    if (FC ["NewsId"] != null)
                    {
                       
                        BON.NewsId = Guid.Parse(FC ["NewsId"]);
                        var Response = await client.PutAsJsonAsync("News", BON);

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
                        var Response = await client.PostAsJsonAsync("News", BON);
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
            }
            else { TempData ["DataNull"] = true; }
            return RedirectToAction("ManageNews", "News");
        }

        public ActionResult GetNews(Guid id)
        {
            var model = Newslst.Where(q => q.NewsId == id).FirstOrDefault();
            return Json(new { NewsId = model.NewsId, Newsname = model.News1 }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RemoveNews(Guid id)
        {
            BONews BON = new BONews();
            BON.NewsId = id;
            var Response = client.DeleteAsync("News/" + BON.NewsId).Result;
            if (Response.IsSuccessStatusCode)
            {
                var Responsedata = Convert.ToBoolean(Response.Content.ReadAsStringAsync().Result);

                if (Responsedata == true)
                {
                    return RedirectToAction("ManageNews", "News");
                }
                else { TempData ["DeleteSuccess"] = false; }
            }
            else { Console.WriteLine("Fail"); }
            return null;
        }

    }
}
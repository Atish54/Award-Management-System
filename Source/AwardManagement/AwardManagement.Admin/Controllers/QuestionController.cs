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

    public class QuestionController : Controller
    {
        HttpClient client = new HttpClient() { BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings ["WebServiceUrl"]) };
        private static List<BOQuestion> Queslst = new List<BOQuestion>();


        public ActionResult ManageQuection()
        {
            var responseTask = client.GetAsync("Question").Result;
            Queslst = JsonConvert.DeserializeObject<List<BOQuestion>>(responseTask.Content.ReadAsStringAsync().Result);
            ViewBag.Data = Queslst.Where(Q => Q.IsDisable == false).OrderByDescending(Q => Q.IsDisable).ToList();



            ViewBag.UpdateSuccess = TempData ["UpdateSuccess"]; // Send View to Update Sucess msg.
            ViewBag.InsertSuccess = TempData ["InsertSuccess"]; // Send View to Insert Sucess msg.
            ViewBag.InsertSuccess = TempData ["InsertSuccess"]; // Send View to Insert Fail msg.
            ViewBag.DataNull = TempData ["DataNull"]; // Send View to Error Sucess msg.
            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> InsertQuection(FormCollection FC)
        {
            if (ModelState.IsValid)
            {
                BOQuestion BOQ = new BOQuestion();

                BOQ.Question1 = FC ["Question1"];

                if (BOQ.Question1 != "")
                {
                    if (FC ["Queid"] != null)
                    {
                        BOQ.QueId = Guid.Parse(FC ["Queid"]);
                        var Response = await client.PutAsJsonAsync("Question", BOQ);

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
                        var Response = await client.PostAsJsonAsync("Question", BOQ);
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
            return RedirectToAction("ManageQuection", "Question");
        }

        public ActionResult GetQuection(Guid id)
        {
            var model = Queslst.Where(q => q.QueId == id).FirstOrDefault();
            return Json(new { QueId = model.QueId, Quename = model.Question1 }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RemoveQuection(Guid id)
        {
            BOQuestion BOQ = new BOQuestion();
            BOQ.QueId = id;
            var Response = client.DeleteAsync("Question/" + BOQ.QueId).Result;
            if (Response.IsSuccessStatusCode)
            {
                var Responsedata = Convert.ToBoolean(Response.Content.ReadAsStringAsync().Result);

                if (Responsedata == true)
                {
                    return RedirectToAction("ManageCategory", "Category");
                }
                else { TempData ["DeleteSuccess"] = false; }
            }
            else { Console.WriteLine("Fail"); }
            return null;
        }

    }
}
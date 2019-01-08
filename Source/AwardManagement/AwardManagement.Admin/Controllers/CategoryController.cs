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
    public class CategoryController : Controller
    {
        // GET: Category

        HttpClient client = new HttpClient() { BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings ["WebServiceUrl"]) };
        private static List<BOCategory> Catelst = new List<BOCategory>();


        public ActionResult ManageCategory()
        {
            var responseTask = client.GetAsync("Category").Result;
            Catelst = JsonConvert.DeserializeObject<List<BOCategory>>(responseTask.Content.ReadAsStringAsync().Result);
            ViewBag.Data = Catelst.OrderByDescending(c => c.IsDisable).ToList();



            ViewBag.UpdateSuccess = TempData ["UpdateSuccess"]; // Send View to Update Sucess msg.
            ViewBag.InsertSuccess = TempData ["InsertSuccess"]; // Send View to Insert Sucess msg.
            ViewBag.DataNull = TempData ["DataNull"]; // Send View to Error Sucess msg.
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> InsertCategory(FormCollection FC)
        {
            // This Method use for Inserting And Updatating data.

            if (ModelState.IsValid)
            {
                BOCategory BOA = new BOCategory();

                BOA.Category1 = FC ["Category1"].Trim();
                BOA.ShortDescription = FC ["ShortDescription"].Trim();
                BOA.LongDescription = FC ["LongDescription"].Trim();

                if (BOA.Category1 != "" && BOA.ShortDescription != "" && BOA.LongDescription != "")
                {
                    if (FC ["cateid"] != null)
                    {
                        BOA.CateId = Guid.Parse(FC ["cateid"]);
                        var Response = await client.PutAsJsonAsync("Category", BOA);

                        if (Response.IsSuccessStatusCode)
                        {
                            TempData ["UpdateSuccess"] = true;

                        }
                        else
                        { ViewBag.UpdateSuccess = false; }
                    }

                    else
                    {
                        var Response = await client.PostAsJsonAsync("Category", BOA);
                        if (Response.IsSuccessStatusCode)
                        {
                            TempData ["InsertSuccess"] = true;
                        }
                        else { ViewBag.InsertSuccess = false; }
                    }
                }
                else
                {
                    TempData ["DataNull"] = true;
                }
                return RedirectToAction("ManageCategory", "Category");
            }
            return null;
        }

        public ActionResult GetCategory(Guid id)
        {
            var model = Catelst.Where(c => c.CateId == id).FirstOrDefault();
            return Json(new { CateId = model.CateId, CateName = model.Category1, ShortDesc = model.ShortDescription, longDesc = model.LongDescription }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RemoveCategory(Guid id)
        {
            BOCategory BOC = new BOCategory();
            BOC.CateId = id;
            var Response = client.DeleteAsync("Category/" + BOC.CateId).Result;
            if (Response.IsSuccessStatusCode)
            {
                return RedirectToAction("ManageCategory", "Category");
            }
            else { Console.WriteLine("Fail"); }
            return null;
        }
    }
}
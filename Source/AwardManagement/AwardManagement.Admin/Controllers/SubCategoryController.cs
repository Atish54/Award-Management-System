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
    public class SubCategoryController : Controller
    {
        HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:62192/api/") };
        private static List<BOCategory> Catelst = new List<BOCategory>();
        private static List<BOSubCategory> subCatelst = new List<BOSubCategory>();

        // GET: Category
        public ActionResult ManageSubCategory()
        {
            // Sub Category Data
            var SubCateresponseTask = client.GetAsync("Subcategory").Result;
            subCatelst = JsonConvert.DeserializeObject<List<BOSubCategory>>(SubCateresponseTask.Content.ReadAsStringAsync().Result);
            ViewBag.SubCateData = subCatelst.OrderByDescending(c => c.IsDisable).ToList();

            // Category Data
            var CateresponseTask = client.GetAsync("Category").Result;
            Catelst = JsonConvert.DeserializeObject<List<BOCategory>>(CateresponseTask.Content.ReadAsStringAsync().Result);
            ViewBag.CateData = Catelst.OrderByDescending(c => c.IsDisable).ToList();

            ViewBag.UpdateSuccess = TempData ["UpdateSuccess"]; // Send View to Update Sucess msg.
            ViewBag.InsertSuccess = TempData ["InsertSuccess"]; // Send View to Insert Sucess msg.
            ViewBag.DataNull = TempData ["DataNull"]; // Send View to Error Sucess msg.
            ViewBag.ChooseCategory = TempData ["ChooseCategory"]; // User Can't Choose Category.


            return View();
        }
        public async System.Threading.Tasks.Task<ActionResult> InsertSubCategory(FormCollection FC)
        {
            // This Method use for Inserting And Updatating data.




            if (ModelState.IsValid && !string.IsNullOrEmpty(FC ["catDrop"]))
            {
                BOSubCategory BOSC = new BOSubCategory();

                BOSC.SubCategory1 = FC ["SubCategory1"];
                BOSC.ShortDescription = FC ["ShortDescription"];
                BOSC.LongDescription = FC ["LongDescription"];
                BOSC.CateId = Guid.Parse(FC ["catDrop"]);

                if (BOSC.SubCategory1 != "" && BOSC.ShortDescription != "" && BOSC.LongDescription != "")
                {
                    if (FC ["SubCateId"] != null)
                    {
                        BOSC.SubCateId = Guid.Parse(FC ["SubCateId"]);
                        var Response = await client.PutAsJsonAsync("Subcategory", BOSC);

                        if (Response.IsSuccessStatusCode)
                        {
                            TempData ["UpdateSuccess"] = true;

                        }
                        else
                        { ViewBag.UpdateSuccess = false; }
                    }

                    else
                    {
                        var Response = await client.PostAsJsonAsync("Subcategory", BOSC);
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
            }
            else { TempData ["DataNull"] = true; }
            return RedirectToAction("ManageSubCategory", "SubCategory");
        }


        public ActionResult GetSubCategory(Guid id)
        {
            var model = subCatelst.Where(c => c.SubCateId == id).FirstOrDefault();
            var data = Json(new { SubCateId = model.SubCateId, SubCateName = model.SubCategory1, ShortDesc = model.ShortDescription, longDesc = model.LongDescription, catdrop = model.CateId }, JsonRequestBehavior.AllowGet);

            return Json(new { SubCateId = model.SubCateId, SubCateName = model.SubCategory1, ShortDesc = model.ShortDescription, longDesc = model.LongDescription, catdrop = model.CateId }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult RemoveSubCategory(Guid id)
        {
            BOSubCategory BOSC = new BOSubCategory();
            BOSC.SubCateId = id;
            var Response = client.DeleteAsync("Subcategory/" + BOSC.SubCateId).Result;
            if (Response.IsSuccessStatusCode)
            {
                return RedirectToAction("ManageSubCategory", "SubCategory");
            }
            else { Console.WriteLine("Fail"); }
            return null;
        }

    }
}
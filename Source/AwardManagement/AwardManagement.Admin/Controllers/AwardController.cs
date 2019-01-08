using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using AwardManagment.BusinessObjects.Model;
using Newtonsoft.Json;

namespace AwardManagement.Admin.Controllers
{
    public class AwardController : Controller
    {
        HttpClient client = new HttpClient() { BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings ["WebServiceUrl"]) };
        private static List<BOCategory> Catelst = new List<BOCategory>();
        private static List<BOSubCategory> subCatelst = new List<BOSubCategory>();
        private static List<BOQuestion> Quelst = new List<BOQuestion>();
        private static List<BOUser> Userlst = new List<BOUser>();
        // GET: Award
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddAward()
        {
            //System.Threading.Thread.Sleep(3000);
            //ViewBag.SubCateData = TempData ["SubCateData"];
            //ViewBag.CateData = TempData ["CateData"];
            //ViewBag.QueData = TempData ["QueData"];
            //ViewBag.Userlst = TempData ["Userlst"];

           

            var SubCateresponseTask = client.GetAsync("Subcategory").Result;
            subCatelst = JsonConvert.DeserializeObject<List<BOSubCategory>>(SubCateresponseTask.Content.ReadAsStringAsync().Result);
            ViewBag.SubCateData = subCatelst.OrderByDescending(c => c.IsDisable).ToList();

            // Category Data
            var CateresponseTask = client.GetAsync("Category").Result;
            Catelst = JsonConvert.DeserializeObject<List<BOCategory>>(CateresponseTask.Content.ReadAsStringAsync().Result);
            ViewBag.CateData = Catelst.OrderByDescending(c => c.IsDisable).ToList();


            // Quection Data
            var QueresponseTask = client.GetAsync("Question").Result;
            Quelst = JsonConvert.DeserializeObject<List<BOQuestion>>(QueresponseTask.Content.ReadAsStringAsync().Result);
            ViewBag.QueData = Quelst.OrderByDescending(c => c.IsDisable).ToList();


            // User Data
            var UserResponseTask = client.GetAsync("User").Result;
            Userlst = JsonConvert.DeserializeObject<List<BOUser>>(UserResponseTask.Content.ReadAsStringAsync().Result);
            ViewBag.Userlst = Userlst.OrderByDescending(c => c.IsDisable).ToList();



            ViewBag.InsertSuccess = TempData ["InsertSuccess"];

            return View();
        }



        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> InsertAward(FormCollection FC)
        {
            DateTime time = Convert.ToDateTime(FC ["StartDate"]);

            string [] data = FC ["optionsCheckboxes"].Split(','); // Get Quection Check Box Value

            Guid [] guid = new Guid [data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                // Convert Check Box to GUID Array
                guid [i] = new Guid(data [i]);
            }

            BOAddAward _BOAddAward = new BOAddAward();
            _BOAddAward.AwardName = FC ["AwardName"];
            _BOAddAward.SubCateId = new Guid(FC ["subcatDrop"]);
            _BOAddAward.ShortDescription = FC ["ShortDescription"];
            _BOAddAward.LongDescription = FC ["LongDescription"];
            _BOAddAward.StartDate = time.Date;
            _BOAddAward.EndDate = Convert.ToDateTime(FC ["EndDate"]);
            _BOAddAward.DateCreated = System.DateTime.Now;
            _BOAddAward.AssesorUserId = new Guid(FC ["assesorDrop"]);
            _BOAddAward.JuryUserId = new Guid(FC ["juryDrop"]);
            _BOAddAward.ChairmanUserId = new Guid(FC ["chairmanDrop"]);
            _BOAddAward.AssesorRoleId = new Guid("cba0ad49-bc26-42d9-a4d4-ea1341235fa4");
            _BOAddAward.JuryRoleId = new Guid("bc29a543-5879-47f1-aa4f-413e699b160b");
            _BOAddAward.ChairmanRoleId = new Guid("f8f2fb12-12a8-4efe-a573-658ec350b5db");
            _BOAddAward.QueId = guid;




            var Response = await client.PostAsJsonAsync("Award", _BOAddAward);
            if (Response.IsSuccessStatusCode)
            {
                TempData ["InsertSuccess"] = true;
                return RedirectToAction("AddAward");
            }
            else { ViewBag.InsertSuccess = false; }

            TempData ["DataNull"] = true;
            return View();
        }
        public ActionResult GetSubCateData(Guid id)
        {
            var lstsub = (subCatelst.Where(s => s.CateId == id && s.IsDisable == false)).ToList<BOSubCategory>();
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(lstsub);
            return Json(result, JsonRequestBehavior.AllowGet);

        }


        public ActionResult ManageAward()
        {
            return View();
        }
        

    }
}
using AwardManagment.BusinessObjects.Model;
using AwardManagment.Data;
using AwardManagment.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AwardManagment.WebApi.Controllers
{
    public class SubCategoriesController : ApiController
    {
        private UnitOfWork _UnitOfWork = new UnitOfWork(new AwardDBEntities());
        // GET: api/SubCategories
        public IEnumerable<BOSubCategory> GetSubCategories(Guid id)
        {
            return _UnitOfWork.SubCategoryRepository.GetSubCategories(id);
        }


        // GET: api/SubCategories/5


        // POST: api/SubCategories
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SubCategories/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SubCategories/5
        public void Delete(int id)
        {
        }
    }
}

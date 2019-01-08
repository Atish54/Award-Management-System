using AwardManagment.BusinessObjects.Model;
using AwardManagment.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AwardManagment.WebApi.Controllers
{
    public class RoleController : ApiController
    {
        private UnitOfWork _UnitOfWorks = new UnitOfWork(new Data.AwardDBEntities());
        // GET: api/Role


        // GET: api/Role/5
        public IEnumerable<BOUser> Get(Guid id)
        {
            var v = _UnitOfWorks.RoleRepositories.GetUsers(id);
            return v;
        }

        // POST: api/Role
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT: api/Role/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Role/5
        public void Delete(int id)
        {
        }
    }
}

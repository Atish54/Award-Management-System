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
    public class ApplicationStageController : ApiController
    {
        private UnitOfWork _UnitOfWork = new UnitOfWork(new AwardDBEntities());
        // GET: api/ApplicationStage
        public IEnumerable<BOApplication> GetApplications(int id)
        {
            return _UnitOfWork.ApplicationRepository.GetAppApplications(id);
        }


        // POST: api/ApplicationStage
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ApplicationStage/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApplicationStage/5
        public void Delete(int id)
        {
        }
    }
}

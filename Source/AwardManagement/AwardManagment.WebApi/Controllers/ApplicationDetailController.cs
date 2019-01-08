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
    public class ApplicationDetailController : ApiController
    {
        // GET: api/ApplicationDetail
        private UnitOfWork _UnitOfWork = new UnitOfWork(new AwardDBEntities());

        public bool Post(BOApplicationDetail _BOApplication)
        {
            try
            {
                _UnitOfWork.ApplicationDetailRepository.InsertApplication(_BOApplication);
                _UnitOfWork.Complete();

                return true;
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
            finally { _UnitOfWork.Dispose(); }
            return false;
        }

        // PUT: api/ApplicationDetail/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApplicationDetail/5
        public void Delete(int id)
        {
        }
    }
}

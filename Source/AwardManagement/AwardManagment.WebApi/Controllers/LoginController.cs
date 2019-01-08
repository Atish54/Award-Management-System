using AwardManagment.BusinessObjects.Model;
using AwardManagment.Data;
using AwardManagment.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace AwardManagment.WebApi.Controllers
{
    public class LoginController : ApiController
    {
        private UnitOfWork _UnitOfWork = new UnitOfWork(new AwardDBEntities());

        public BOUser PostLogin(BOLogin id)
        {
            BOUser tmp = _UnitOfWork.UserRepositories.GetUser(id);
            if (tmp != null)
            {
                return tmp; 
            }
            return null;
        }

    }
}

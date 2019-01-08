using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AwardManagment.BusinessObjects.Model;
using AwardManagment.Data.Repository;
namespace AwardManagment.WebApi.Controllers
{
    public class UserController : ApiController
    {
        private UnitOfWork _UnitOfWorks = new UnitOfWork(new Data.AwardDBEntities());

        

        public IEnumerable<BOUser> GetUsers()
        {
            return _UnitOfWorks.UserRepositories.GetAllUser();
        }
        [Route("api/User/Usercheck")]
        [HttpPost]
        public bool GetUser(BOUser id)
        {
            return _UnitOfWorks.UserRepositories.Emailcheck(id.Email);

        }
        public BOUser GetUser(Guid id)
        {
            return _UnitOfWorks.UserRepositories.GetUser(id);
        }

       
       
        //public bool GetUser(BOLogin id)
        //{
        //    BOUser tmp = _UnitOfWorks.UserRepositories.GetUser(id);
        //    if (tmp != null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}
        public bool PostUser(BOUser _BOUser)
        {
            try
            {
                _UnitOfWorks.UserRepositories.InsertUser(_BOUser);
                _UnitOfWorks.Complete();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                _UnitOfWorks.Dispose();
            }

        }
        public bool PutUser(BOUser _BOUser)
        {
            try
            {
                _UnitOfWorks.UserRepositories.UpdateUser(_BOUser);
                _UnitOfWorks.Complete();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                _UnitOfWorks.Dispose();
            }

        }
        public bool DeleteUser(Guid id)
        {
            try
            {
                _UnitOfWorks.UserRepositories.RemoveUser(id);
                _UnitOfWorks.Complete();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                _UnitOfWorks.Dispose();
            }
        }

       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AwardManagment.Data;
using AwardManagment.BusinessObjects.Model;
using AwardManagment.Data.Repository;

namespace AwardManagment.WebApi.Controllers
{
    public class AwardController : ApiController
    {
        private UnitOfWork _UnitOfWork = new UnitOfWork(new AwardDBEntities());
        [Route("api/AwardList/{id}")]
        public IEnumerable<BOAward> GetAwards(Guid id)
        {
            return _UnitOfWork.AwardRepository.GetAwardList(id);
        }
        public IEnumerable<BOAward> GetAward()
        {
            return _UnitOfWork.AwardRepository.GetAllAward();
        }
        public BOAward GetAward(Guid id)
        {
            return _UnitOfWork.AwardRepository.GetAward(id);
        }

        public bool PostAward(BOAddAward _BOAddAward)
        {



            BOAward _BOAward = new BOAward();
            _BOAward.DateCreated = _BOAddAward.DateCreated;
            _BOAward.StartDate = _BOAddAward.StartDate;
            _BOAward.EndDate = _BOAddAward.EndDate;
            _BOAward.LongDescription = _BOAddAward.LongDescription;
            _BOAward.ShortDescription = _BOAddAward.ShortDescription;
            _BOAward.SubCateId = _BOAddAward.SubCateId;
            _BOAward.AwardName = _BOAddAward.AwardName;
           
            Guid g;
            try
            {
                g = _UnitOfWork.AwardRepository.InsertAward(_BOAward);
                _UnitOfWork.Complete();

                BOUserRole _BOUserRole1 = new BOUserRole();
                _BOUserRole1.UserId = _BOAddAward.AssesorUserId;
                _BOUserRole1.RoleId = _BOAddAward.AssesorRoleId;
                _BOUserRole1.AwardId = g;

                _UnitOfWork.UserRoleRepositories.AssignRole(_BOUserRole1);
                _UnitOfWork.Complete();


                BOUserRole _BOUserRole2 = new BOUserRole();
                _BOUserRole2.UserId = _BOAddAward.ChairmanUserId;
                _BOUserRole2.RoleId = _BOAddAward.ChairmanRoleId;
                _BOUserRole2.AwardId = g;

                _UnitOfWork.UserRoleRepositories.AssignRole(_BOUserRole2);
                _UnitOfWork.Complete();


                BOUserRole _BOUserRole3 = new BOUserRole();
                _BOUserRole3.UserId = _BOAddAward.JuryUserId;
                _BOUserRole3.RoleId = _BOAddAward.JuryRoleId;
                _BOUserRole3.AwardId = g;

                _UnitOfWork.UserRoleRepositories.AssignRole(_BOUserRole3);
                _UnitOfWork.Complete();


                for (int i = 0; i < _BOAddAward.QueId.Length; i++)
                {
                    BOAwardQuection _BOAwardQuection = new BOAwardQuection();
                    _BOAwardQuection.AwdId = g;
                    _BOAwardQuection.QueId = _BOAddAward.QueId [i];
                    _UnitOfWork.AwardQuestionsRepository.InsertCategory(_BOAwardQuection);
                    _UnitOfWork.Complete();
                }


                return true;
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
            finally { _UnitOfWork.Dispose(); }
            return false;
        }
        public bool PutAward(BOAward _BOAward)
        {
            try
            {
                _UnitOfWork.AwardRepository.UpdateAward(_BOAward);
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
        public bool DeleteAward(Guid id)
        {
            try
            {
                _UnitOfWork.AwardRepository.Remove(id);
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

    }
}

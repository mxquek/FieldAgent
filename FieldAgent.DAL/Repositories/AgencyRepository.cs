using FieldAgent.Core;
using FieldAgent.Core.Entities;
using FieldAgent.Core.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldAgent.DAL.Repositories
{
    public class AgencyRepository : IAgencyRepository
    {
        public DbFactory DbFac { get; set; }
        public LocationRepository LocationRepository { get; set; }
        //public MissionRepository MissionRepository { get; set; }
       

        public AgencyRepository(DbFactory dbfac, LocationRepository locationRepo)
        {
            DbFac = dbfac;
            LocationRepository = locationRepo;
            //MissionRepository = missionRepo;
        }


        public Response Delete(int agencyId)
        {
            Response result = new Response();
            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    Response<List<Location>> locations = LocationRepository.GetByAgency(agencyId);
                    foreach (Location location in locations.Data)
                    {
                        db.Locations.Remove(location);
                    }

                    //Need to also remove from missions

                    db.Agencies.Remove(db.Agencies.Find(agencyId));
                    result.Success = true;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public Response<Agency> Get(int agencyId)
        {
            Response<Agency> result = new Response<Agency>();
            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    result.Data = db.Agencies.Find(agencyId);
                    result.Success = true;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            if (result.Data == null)
            {
                result.Success = false;
                result.Message = $"Agency #{agencyId} not found";
            }
            return result;
        }

        public Response<List<Agency>> GetAll()
        {
            Response<List<Agency>> result = new Response<List<Agency>>();
            using (var db = DbFac.GetDbContext())
            {
                result.Data = db.Agencies.ToList();
                result.Success = true;
            }
            if (result.Data == null)
            {
                result.Success = false;
                result.Message = $"Could not retireve all agencies";
            }
            return result;
        }

        public Response<Agency> Insert(Agency agency)
        {
            Response<Agency> result = new Response<Agency>();
            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    db.Agencies.Add(agency);
                    result.Data = agency;
                    result.Success = true;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public Response Update(Agency agency)
        {
            Response result = new Response();
            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    db.Agencies.Update(agency);
                    result.Success = true;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }
    }
}

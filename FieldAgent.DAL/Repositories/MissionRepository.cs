using FieldAgent.Core;
using FieldAgent.Core.Entities;
using FieldAgent.Core.Interfaces.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldAgent.DAL.Repositories
{
    public class MissionRepository : IMissionRepository
    {
        public DbFactory DbFac { get; set; }
        public MissionRepository(DbFactory dbfac)
        {
            DbFac = dbfac;
        }

        public Response<Mission> Insert(Mission mission)
        {
            throw new NotImplementedException();
        }

        public Response Update(Mission mission)
        {
            throw new NotImplementedException();
        }

        public Response Delete(int missionId)
        {
            Response result = new Response();
/*            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    var missions = db.Missions.Include(m => m.Agents).Where(m => m.MissionId == missionId);
                    foreach (Mission mission in missions)
                    {
                        db.Missions.Remove(mission);
                    }

                    result.Success = true;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }*/
            return result;
        }

        public Response<Mission> Get(int missionId)
        {
            throw new NotImplementedException();
        }

        public Response<List<Mission>> GetByAgency(int agencyId)
        {
            Response<List<Mission>> result = new Response<List<Mission>>();
            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    result.Data = db.Missions
                                    .Where(m => m.AgencyId == agencyId).ToList();
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
                result.Message = $"Missions for Agency #{agencyId} not found";
            }

            return result;
        }

        public Response<List<Mission>> GetByAgent(int agentId)
        {
            throw new NotImplementedException();
        }
    }
}

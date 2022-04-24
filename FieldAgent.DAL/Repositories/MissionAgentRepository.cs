using FieldAgent.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldAgent.DAL.Repositories
{
    public class MissionAgentRepository
    {
        public DbFactory DbFac { get; set; }
        public MissionAgentRepository(DbFactory dbfac)
        {
            DbFac = dbfac;
        }

        public Response Delete(int missionId, int agentId)
        {
            Response result = new Response();
            /*try
            {
                using (var db = DbFac.GetDbContext())
                {
                    db.MissionAgents.Remove(db.MissionAgents.Find(missionId, agentId));
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
    }
}

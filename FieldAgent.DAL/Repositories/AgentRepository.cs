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
    public class AgentRepository : IAgentRepository
    {
        public DbFactory DbFac { get; set; }

        public AgentRepository(DbFactory dbfac)
        {
            DbFac = dbfac;
        }
        public Response Delete(int agentId)
        {
            Response result = new Response<Agent>();
            using (var db = DbFac.GetDbContext())
            {
                var aliases = db.Aliases
                    .Where(a => a.AgentId == agentId);
                foreach (var alias in aliases)
                {
                    db.Aliases.Remove(alias);
                }

                var agencyAgents = db.AgencyAgents
                                    .Where(aa => aa.AgentId == agentId);
                foreach(var agencyAgent in agencyAgents)
                {
                    db.AgencyAgents.Remove(agencyAgent);
                }

                var missionAgents = db.MissionAgents
                                        .Where(ma => ma.AgentId == agentId);
                foreach (var missionAgent in missionAgents)
                {
                    db.MissionAgents.Remove(missionAgent);
                }
                db.Agents.Remove(db.Agents.Find(agentId));
                db.SaveChanges();

                result.Success = true;
            }
            return result;
        }
        public Response<Agent> Get(int agentId)
        {
            Response<Agent> result = new Response<Agent>();
            using(var db = DbFac.GetDbContext())
            {
                result.Data = db.Agents.Find(agentId);
                result.Success = true;
            }
            if(result.Data == null)
            {
                result.Success = false;
                result.Message = $"Agent #{agentId} not found";
            }
            return result;
        }

        public Response<List<Mission>> GetMissions(int agentId)
        {
            Response<List<Mission>> result = new Response<List<Mission>>();
            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    result.Data = db.MissionAgents
                                        .Include(ma => ma.Mission)
                                        .Where(ma => ma.AgentId == agentId)
                                        .Select(ma => ma.Mission)
                                        .ToList();

                    /*Agent targetAgent = db.Agents
                                          .Include(a => a.MissionAgents)
                                          .Single(a => a.AgentId == agentId);
                    result.Data = db.Missions.Where(m => m.Agents.Any(a => a.AgentId == agentId)).ToList();
                    */
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
                result.Message = $"No missions found for Agent #{agentId}";
            }

            return result;
        }

        public Response<Agent> Insert(Agent agent)
        {
            throw new NotImplementedException();
        }

        public Response Update(Agent agent)
        {
            throw new NotImplementedException();
        }
    }
}

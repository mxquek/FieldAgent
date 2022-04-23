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
    public class AgentRepository : IAgentRepository
    {
        public DbFactory DbFac { get; set; }

        public AgentRepository(DbFactory dbfac)
        {
            DbFac = dbfac;
        }
        public Response Delete(int agentId)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldAgent.Core.Entities
{
    [Table("MissionAgent")]
    public class MissionAgent
    {
        public int MissionId { get; set; }
        public int AgentId  { get; set; }

        public Mission Mission { get; set; }
        public Agent Agent { get; set; }

        public override bool Equals(object obj)
        {
            return obj is MissionAgent missionAgent &&
                missionAgent.MissionId == MissionId &&
                missionAgent.AgentId == AgentId;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(MissionId, AgentId);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldAgent.Core.Entities
{
    [Table("Mission")]
    public class Mission
    {
        [Key]
        public int MissionId { get; set; }
        public string CodeName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ProjectedEndDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public decimal OperationalCost { get; set; }
        public string? Notes { get; set; }

        //Many-to-one Agency
        public int AgencyId { get; set; }
        public Agency Agency { get; set; }

        //Many-to-many Agents
        public List<MissionAgent> MissionAgents { get; set; }
        //public List<Agent> Agents { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Mission mission &&
                MissionId == mission.MissionId &&
                CodeName == mission.CodeName &&
                StartDate == mission.StartDate &&
                ProjectedEndDate == mission.ProjectedEndDate &&
                ActualEndDate == mission.ActualEndDate &&
                OperationalCost == mission.OperationalCost &&
                Notes == mission.Notes &&
                AgencyId == mission.AgencyId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(MissionId, CodeName, StartDate, ProjectedEndDate, ActualEndDate, OperationalCost,Notes,AgencyId);
        }
    }
}

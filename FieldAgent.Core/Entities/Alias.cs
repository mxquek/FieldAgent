using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldAgent.Core.Entities
{
    [Table("Alias")]
    public class Alias
    {
        [Key]
        public int AliasId { get; set; }
        public string AliasName { get; set; }
        public Guid? InterpolId { get; set; }
        public string? Persona { get; set; }

        //Many-to-one
        public int AgentId { get; set; }
        public Agent Agent { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Alias alias &&
                AliasId == alias.AliasId &&
                AliasName == alias.AliasName &&
                InterpolId == alias.InterpolId &&
                Persona == alias.Persona &&
                AgentId == alias.AgentId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AliasId, AliasName, InterpolId, Persona, AgentId);
        }
    }
}

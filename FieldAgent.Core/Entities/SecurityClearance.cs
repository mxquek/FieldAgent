using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldAgent.Core.Entities
{
    [Table("SecurityClearance")]
    public class SecurityClearance
    {
        [Key]
        public int SecurityClearanceId { get; set; }
        public string SecurityClearanceName { get; set; }

        //One-to-Many AgencyAgents
        public List<AgencyAgent> AgencyAgents { get; set; }
    }
}

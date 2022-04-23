using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldAgent.Core.Entities
{
    [Table("Agency")]
    public class Agency
    {
        [Key]
        public int AgencyId { get; set; }
        public string ShortName { get; set; }
        public string? LongName { get; set; }

        //One-to-many
        public List<AgencyAgent> AgencyAgents { get; set; }
        public List<Location> Locations { get; set; }
        public List<Mission> Missions { get; set; }
    }
}

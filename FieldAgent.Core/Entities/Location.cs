﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldAgent.Core.Entities
{
    [Table("Location")]
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string Street1 { get; set; }
        public string? Street2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string CountryCode { get; set; }

        //Many-to-one Agency
        public int AgencyId { get; set; }
        public Agency Agency { get; set; }
    }
}

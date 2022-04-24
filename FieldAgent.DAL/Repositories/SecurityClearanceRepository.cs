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
    public class SecurityClearanceRepository : ISecurityClearanceRepository
    {
        public DbFactory DbFac { get; set; }
        public SecurityClearanceRepository(DbFactory dbfac)
        {
            DbFac = dbfac;
        }
        public Response<SecurityClearance> Get(int securityClearanceId)
        {
            Response<SecurityClearance> result = new Response<SecurityClearance>();
            using (var db = DbFac.GetDbContext())
            {
                result.Data = db.SecurityClearances.Find(securityClearanceId);
                result.Success = true;
            }
            if (result.Data == null)
            {
                result.Success = false;
                result.Message = $"Security Clearance #{securityClearanceId} not found";
            }
            return result;
        }

        public Response<List<SecurityClearance>> GetAll()
        {
            Response<List<SecurityClearance>> result = new Response<List<SecurityClearance>>();
            using (var db = DbFac.GetDbContext())
            {
                result.Data = db.SecurityClearances.ToList();
                                //.Select(sc=>sc)
                                //.ToList();
                result.Success = true;
            }
            if (result.Data == null)
            {
                result.Success = false;
                result.Message = $"Could not retireve all Security Clearances";
            }
            return result;
        }
    }
}

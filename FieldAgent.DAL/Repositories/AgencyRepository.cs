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
    public class AgencyRepository : IAgencyRepository
    {
        public DbFactory DbFac { get; set; }

        public AgencyRepository(DbFactory dbfac)
        {
            DbFac = dbfac;
        }


        public Response Delete(int agencyId)
        {
            throw new NotImplementedException();
        }

        public Response<Agency> Get(int agencyId)
        {
            throw new NotImplementedException();
        }

        public Response<List<Agency>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Response<Agency> Insert(Agency agency)
        {
            throw new NotImplementedException();
        }

        public Response Update(Agency agency)
        {
            throw new NotImplementedException();
        }
    }
}

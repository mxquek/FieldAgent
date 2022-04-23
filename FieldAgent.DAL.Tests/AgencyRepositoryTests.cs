using NUnit.Framework;
using Microsoft.Extensions.Configuration;
using FieldAgent.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FieldAgent.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FieldAgent.DAL.Tests
{
    public class AgencyRepositoryTests
    {
        AgencyRepository db;
        DbFactory dbf;

        [SetUp]
        public void Setup()
        {
            ConfigProvider cp = new ConfigProvider();
            dbf = new DbFactory(cp.Config, FactoryMode.TEST);
            db = new AgencyRepository(dbf);
            dbf.GetDbContext().Database.ExecuteSqlRaw("SetKnownGoodState");
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}

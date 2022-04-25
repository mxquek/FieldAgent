using FieldAgent.Core;
using FieldAgent.Core.DTOs;
using FieldAgent.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldAgent.DAL.Tests
{
    public class ReportsRepositoryTests
    {
        ReportsRepository db;
        DbFactory dbf;

        [SetUp]
        public void Setup()
        {
            ConfigProvider cp = new ConfigProvider();
            dbf = new DbFactory(cp.Config, FactoryMode.TEST);
            db = new ReportsRepository(cp.Config);
            dbf.GetDbContext().Database.ExecuteSqlRaw("SetKnownGoodState");
        }

        [Test]
        public void GetTopAgents_ReturnTopAgents()
        {
            Response<List<TopAgentListItem>> result = db.GetTopAgents();
            Assert.IsTrue(result.Success);
            Assert.AreEqual("Rowe, Daryl", result.Data[0].NameLastFirst);
            Assert.AreEqual(new DateTime(1973,03,14), result.Data[0].DateOfBirth);
            Assert.AreEqual(1, result.Data[0].CompletedMissionCount);
        }
    }
}

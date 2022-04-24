using FieldAgent.Core;
using FieldAgent.Core.Entities;
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
    public class MissionRepositoryTests
    {
        MissionRepository db;
        DbFactory dbf;

        public static Mission expectedMission = new Mission
        {
            MissionId = 1,
            CodeName = "Jordanna",
            StartDate = new DateTime(2019, 12, 13),
            ProjectedEndDate = new DateTime(2015, 3, 4),
            ActualEndDate = new DateTime(2016,9,22),
            OperationalCost = 2612.88M,
            Notes = null,

            AgencyId = 1
        };

        [SetUp]
        public void Setup()
        {
            ConfigProvider cp = new ConfigProvider();
            dbf = new DbFactory(cp.Config, FactoryMode.TEST);
            db = new MissionRepository(dbf);
            dbf.GetDbContext().Database.ExecuteSqlRaw("SetKnownGoodState");
        }

        [Test]
        public void GetByAgency_GivenAgencyId_ReturnMissions()
        {
            List<Mission> expected = new List<Mission>();
            expected.Add(expectedMission);

            Response<List<Mission>> actual = db.GetByAgency(1);

            Assert.IsTrue(actual.Success);
            Assert.AreEqual(actual.Data, expected);
        }

        [Test]
        public void Delete_GivenMissionId_DeleteMission()
        {
            Response actual = db.Delete(1);

            Assert.IsTrue(actual.Success);
            Assert.False(db.Get(1).Success);
        }
    }
}

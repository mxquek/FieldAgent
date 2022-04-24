using FieldAgent.Core;
using FieldAgent.Core.Entities;
using FieldAgent.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FieldAgent.DAL.Tests
{
    public class AgentRepositoryTests
    {

        AgentRepository db;
        DbFactory dbf;
        Agent expectedAgent = new Agent
        {
            AgentId = 1,
            FirstName = "Faydra",
            LastName = "Vamplers",
            DateOfBirth = new DateTime(1989, 3, 14),
            Height = 80.24M
        };


        [SetUp]
        public void Setup()
        {
            ConfigProvider cp = new ConfigProvider();
            dbf = new DbFactory(cp.Config, FactoryMode.TEST);
            db = new AgentRepository(dbf);
            dbf.GetDbContext().Database.ExecuteSqlRaw("SetKnownGoodState");
        }

        [Test]
        public void Get_GivenAgentId_ReturnAgent()
        {
            Response <Agent> result = db.Get(1);
            Assert.True(result.Success);
            Assert.AreEqual(result.Data, expectedAgent);
        }

        [Test]
        public void GetMissions_GivenAgentId_ReturnMissions()
        {
            List<Mission> expected = new List<Mission>();
            expected.Add(MissionRepositoryTests.expectedMission);

            
            Response<List<Mission>> result = db.GetMissions(1);
            Assert.True(result.Success);
            Assert.AreEqual(result.Data, expected);
        }

        /*[Test]
        public void Delete_GivenAgentId_DeleteAgent()
        {
            Response<Agent> result = db.Delete(1);
            Assert.True(result.Success);
        }*/
    }
}
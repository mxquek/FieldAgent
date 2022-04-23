using FieldAgent.Core;
using FieldAgent.Core.Entities;
using FieldAgent.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

namespace FieldAgent.DAL.Tests
{
    public class AgentRepositoryTests
    {

        AgentRepository db;
        DbFactory dbf;
        Agent expected = new Agent
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
        public void Get_GivenExisitingAgentId_ReturnAgent()
        {
            Response <Agent> result = db.Get(1);
            Assert.True(result.Success);
            Assert.AreEqual(result.Data, expected);
        }
    }
}
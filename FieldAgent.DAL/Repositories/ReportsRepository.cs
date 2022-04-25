﻿using FieldAgent.Core;
using FieldAgent.Core.DTOs;
using FieldAgent.Core.Interfaces.DAL;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldAgent.DAL.Repositories
{
    public class ReportsRepository : IReportsRepository
    {
        private readonly IConfigurationRoot _Config;
        private readonly string _ConnectionString;
        private readonly FactoryMode _Mode;

        public ReportsRepository(IConfigurationRoot config)
        {
            _Config = config;
            string environment = _Mode == FactoryMode.TEST ? "Test" : "Prod";
            _ConnectionString = _Config[$"ConnectionStrings:{environment}"];
        }

        public Response<List<ClearanceAuditListItem>> AuditClearance(int securityClearanceId, int agencyId)
        {
            Response<List<ClearanceAuditListItem>> result = new Response<List<ClearanceAuditListItem>>();
            using(var connection = new SqlConnection(_ConnectionString))
            {
                var command = new SqlCommand("", connection);
            }
            return result;
            throw new NotImplementedException();
        }

        public Response<List<PensionListItem>> GetPensionList(int agencyId)
        {
            Response<List<PensionListItem>> result = new Response<List<PensionListItem>>();
            using (var connection = new SqlConnection(_ConnectionString))
            {
                var command = new SqlCommand("", connection);
            }
            return result;
            throw new NotImplementedException();
        }

        public Response<List<TopAgentListItem>> GetTopAgents()
        {
            Response<List<TopAgentListItem>> result = new Response<List<TopAgentListItem>>();
            result.Data = new List<TopAgentListItem>();
            using (var connection = new SqlConnection(_ConnectionString))
            {
                var command = new SqlCommand("TopAgents", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TopAgentListItem item = new TopAgentListItem();
                        item.NameLastFirst = reader["NameLastFirst"].ToString();
                        item.DateOfBirth = (DateTime)reader["DateOfBirth"];
                        item.CompletedMissionCount = (int)reader["NumberOfMissions"];

                        result.Data.Add(item);
                    }
                    result.Success = true;
                }
            }
            return result;
        }
    }
}

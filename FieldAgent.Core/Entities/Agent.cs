﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldAgent.Core.Entities
{
    [Table("Agent")]
    public class Agent
    {

        [Key]
        public int AgentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Height { get; set; }

        //One-to-many
        public List<AgencyAgent> AgencyAgents { get; set; }
        public List<Mission> Missions { get; set; }
        public List<Alias> Aliases { get; set; }


        public override bool Equals(object obj)
        {
            return obj is Agent agent &&
                AgentId == agent.AgentId &&
                FirstName == agent.FirstName &&
                LastName == agent.LastName &&
                DateOfBirth == agent.DateOfBirth &&
                Height == agent.Height;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AgentId, FirstName, LastName, DateOfBirth, Height);
        }
        /*public Agent(int agentId, string firstName, string lastName, DateTime DOB, decimal height)
        {
            AgentId = agentId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = DOB;
            Height = height;
        }*/
    }
}

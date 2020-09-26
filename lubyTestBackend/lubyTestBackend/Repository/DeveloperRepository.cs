﻿using Dapper;
using lubyTestBackend.Domain;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace lubyTestBackend.Repository
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly string _connectionString;

        public DeveloperRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("lubyServer");
        }

        public int Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = $"delete from tbl_developer where id = {id}";

            var result =  connection.Execute(query);

            return result;
        }

        public IEnumerable<DeveloperDomain> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);

            var developers = connection.Query<DeveloperDomain>("select * from tbl_developer");

            return developers;
        }

        public int Insert(DeveloperDomain developer)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = $"insert into tbl_developer (full_name, email) values ('{developer.FullName}', '{developer.Email}')";

            var result = connection.Execute(query);

            return result;
        }

        public int Update(DeveloperDomain developer)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = $"update tbl_developer set full_name = '{developer.FullName}', email = '{developer.Email}' where id = {developer.Id}";

            var result = connection.Execute(query);

            return result;
        }
    }
}

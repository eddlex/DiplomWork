﻿using BackEnd.Models.Input;
using BackEnd.Services.Db;
using BackEnd.Services.Interfaces;
using Dapper;
using System.Data;
using BackEnd.Helpers;
using BackEnd.Models.Output;
using FrontEnd.Helpers;

namespace BackEnd.Services.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DbService dbService;
        public DepartmentService(IDbService dbService)
        {
            this.dbService = (DbService)dbService;
        }

        public async Task<List<Department?>> GetDepartments()
        {
            var departments = (await dbService.QueryAsync<Department>("spGetDepartments")).ToList();
          
            if (departments == null || !departments.Any())
                throw Alert.Create(Constants.Error.NotExistAnyDepartment);
            
            return departments;
        }

        public async Task<bool> AddDepartment(DepartmentPost department)
        {
            await using var cmd = dbService.CreateCommand();
            cmd.CommandText = "spAddDepartment";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", department.Name);
            cmd.Parameters.AddWithValue("@Description", department.Description);

            return Convert.ToBoolean(await cmd.ExecuteNonQueryAsync());
        }


        public async Task<bool> DelDepartment(int id)
        {
            using var cmd = dbService.CreateCommand();
            cmd.CommandText = "spDelDepartment";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", id);

            return Convert.ToBoolean(await cmd.ExecuteNonQueryAsync());
        }





    }
}

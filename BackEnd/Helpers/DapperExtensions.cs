using System.Data;
using System.Data.SqlClient;
using BackEnd.Services.Db;
using Dapper;
using FrontEnd.Helpers;

namespace BackEnd.Helpers;

public static class DapperExtensions
{
    public static async Task<IEnumerable<T?>> QueryAsync<T>(this DbService dbService,
                                              string procedureName,
                                              object? param = default)
    {
        try
        {
            await using var connection = dbService.CreateConnection();
            return await connection.QueryAsync<T>(procedureName, param, commandType: CommandType.StoredProcedure);
        }
        catch (SqlException e)
        {
            throw Alert.Create(e);
           
        }
        catch (System.Exception e)
        {
            throw Alert.Create(e);
        }
    }
}
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
                                              object? param)
    {
        try
        {
            await using var connection = dbService.CreateConnection();
            return await connection.QueryAsync<T>(procedureName, param, commandType: CommandType.StoredProcedure);
        }
        catch (SqlException e)
        {
            throw Constants.Errors.CreateException(e.Number);
        }
        catch (Exception e)
        {
            throw Constants.Errors.CreateException(e.Message);
        }
    }
}
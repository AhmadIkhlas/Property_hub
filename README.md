using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        using var dbContext = new YourDbContext();

        var parameterValue = "your_parameter_value";
        var results = ExecuteStoredProcedure(dbContext, "YourStoredProcedureName", parameterValue);

        // Process the results...
    }

    static List<Dictionary<string, object>> ExecuteStoredProcedure(DbContext dbContext, string storedProcedureName, string parameterValue)
    {
        var parameter = new SqlParameter("@YourParameterName", parameterValue);

        using var command = dbContext.Database.GetDbConnection().CreateCommand();
        command.CommandText = storedProcedureName;
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(parameter);

        dbContext.Database.OpenConnection(); // Ensure connection is open

        using var reader = command.ExecuteReader();
        var results = new List<Dictionary<string, object>>();

        while (reader.Read())
        {
            var row = new Dictionary<string, object>();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                row.Add(reader.GetName(i), reader.GetValue(i));
            }

            results.Add(row);
        }

        return results;
    }
}

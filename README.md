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

        var results = ExecuteStoredProcedure(dbContext, "YourStoredProcedureName");

        // Process the results
        if (results != null && results.Any())
        {
            // Get column names
            var columnNames = results[0].Keys.ToList();

            // Print column names
            Console.WriteLine("Column Names:");
            foreach (var columnName in columnNames)
            {
                Console.WriteLine(columnName);
            }

            // Print row values
            Console.WriteLine("Row Values:");
            foreach (var row in results)
            {
                foreach (var columnName in columnNames)
                {
                    Console.WriteLine($"{columnName}: {row[columnName]}");
                }
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("No results returned from the stored procedure.");
        }
    }

    static List<Dictionary<string, object>> ExecuteStoredProcedure(DbContext dbContext, string storedProcedureName)
    {
        using var command = dbContext.Database.GetDbConnection().CreateCommand();
        command.CommandText = storedProcedureName;
        command.CommandType = CommandType.StoredProcedure;

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

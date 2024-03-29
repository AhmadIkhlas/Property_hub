# Property_hub


using (var dbContext = new YourDbContext())
        {
            // Replace "YourStoredProcedureName" with the name of your stored procedure
            var results = dbContext.Set<YourResultType>()
                                   .FromSqlRaw("EXEC YourStoredProcedureName")
                                   .ToList();

            if (results.Any())
            {
                var properties = results.First().GetType().GetProperties();

                // Print column names
                Console.WriteLine("Column Names:");
                foreach (var property in properties)
                {
                    Console.WriteLine(property.Name);
                }

                // Print row values
                Console.WriteLine("Row Values:");
                foreach (var row in results)
                {
                    foreach (var property in properties)
                    {
                        Console.WriteLine($"{property.Name}: {property.GetValue(row)}");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No results returned from the stored procedure.");
            }
        }
    }

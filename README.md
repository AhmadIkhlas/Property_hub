# Property_hub


        if (results.Any())
        {
            // Get column names from the dictionary keys of the first row
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

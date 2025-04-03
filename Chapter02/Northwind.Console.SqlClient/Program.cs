using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;  // To use SqçConnection and so on
ConfigureConsole();

#region Set up the connection string builder
SqlConnectionStringBuilder builder = new()
{
    InitialCatalog = "Northwind",
    MultipleActiveResultSets = true,
    Encrypt = true,
    TrustServerCertificate = true,
    ConnectTimeout = 10 //Default is 30 seconds.
};
WriteLine("Connect to:");
WriteLine(" 1 - SQL Server on local machine");
WriteLine(" 2 - Azure SQL Database");
WriteLine(" 3 - SQL Server on local machine");
WriteLine();
WriteLine("Press key: ");
ConsoleKey key = ReadKey().Key;
WriteLine();WriteLine();

switch (key)
{
    case ConsoleKey.D1 or ConsoleKey.NumPad1:
        builder.DataSource = ".";
        break;

    case ConsoleKey.D2 or ConsoleKey.NumPad2:
        builder.DataSource =
        // use your Azure SQL Database server name.
        "tcp:apps-services-book.database.windows.net,1433";
        break;

    case ConsoleKey.D3 or ConsoleKey.NumPad3:
        builder.DataSource = "tcp:127.0.0.1,1433";
        break;

    default:
        WriteLine("No data source selected.");
        return;
}

WriteLine("Authenticate using:");
WriteLine(" 1 - Windows Integrated Security");
WriteLine(" 2 - SQL Login, for example, sa");
WriteLine();
WriteLine("Press a key: ");
key = ReadKey().Key;
WriteLine();WriteLine();

if (key is ConsoleKey.D1 or ConsoleKey.NumPad1)
{
    builder.IntegratedSecurity = true;
}
else if (key is ConsoleKey.D2 or ConsoleKey.NumPad2)
{
    Write("Enter your SQL Server user ID: ");
    string? userId = ReadLine();
    
}
#endregion
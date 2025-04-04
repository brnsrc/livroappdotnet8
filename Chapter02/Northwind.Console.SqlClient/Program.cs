﻿using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;  // To use SqçConnection and so on
using System.Data; //To useb CommaandType

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
WriteLine(" 3 - Azure SQL Edge");
WriteLine();
WriteLine("Press key: ");
ConsoleKey key = ReadKey().Key;
WriteLine();WriteLine();

switch (key)
{
    case ConsoleKey.D1 or ConsoleKey.NumPad1:
        builder.DataSource = @".\SQLEXPRESS";
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
    if (string.IsNullOrWhiteSpace(userId))
    {
        WriteLine("User ID cannot be empty or null.");
        return;
    }
    builder.UserID = userId;
    Write("Enter your SQL Server password: ");
    string? password = ReadLine();
    if (string.IsNullOrWhiteSpace(password))
    {
        WriteLine("Password cannot be empty or null");
        return;
    }
    builder.Password = password;
    builder.PersistSecurityInfo = false;
}
else
{
    WriteLine("No authentication selected.");
    return;
}
#endregion

#region Create and open the connection
SqlConnection connection = new(builder.ConnectionString);
WriteLine(connection.ConnectionString);
WriteLine();
connection.StateChange += Connection_StateChange;
connection.InfoMessage += Connection_InfoMessage;

try
{
    WriteLine("Opening connection. please wait up to {0} seconds ...", builder.ConnectTimeout);
    WriteLine();
    connection.Open();
    WriteLine($"SQL Server version: {connection.ServerVersion}");
}
catch (SqlException ex)
{
    WriteInColor($"SQL Exception: {ex.Message}", ConsoleColor.Red);
}

#endregion

#region Create Command
    SqlCommand cmd = connection.CreateCommand();
    cmd.CommandType = CommandType.Text;
    cmd.CommandText = "Select ProductId, ProductName, UnitPrice FROM Products";

    SqlDataReader r = cmd.ExecuteReader();
    string horizontalLine = new string('-', 60);
    WriteLine(horizontalLine);

    WriteLine("|{0,5}|{1,-35}|{2,10}|", 
    arg0: "Id", arg1:"Name", arg2:"Price");
    WriteLine(horizontalLine);

    while (r.Read())
    {
        WriteLine("|{0,5}|{1,35}|{2,10:C}|",
        r.GetInt32("ProductId"), 
        r.GetString("ProductName"),
        r.GetDecimal("UnitPrice"));
    }

    WriteLine(horizontalLine);
    r.Close();

#endregion

connection.Close();
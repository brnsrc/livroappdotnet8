using Microsoft.Data.SqlClient; //To use SqlConnectionStringBuilder
using Microsoft.EntityFrameworkCore; //ToQueryString, GetConnectionString
using Northwind.Models; //to use NorthwindDb

SqlConnectionStringBuilder builder = new();
builder.InitialCatalog = "Northwind";
builder.MultipleActiveResultSets = true;
builder.Encrypt = true;
builder.TrustServerCertificate = true;
builder.ConnectTimeout = 10;

WriteLine("Connect to:");
WriteLine(" 1 - SQL Server on loca machine");
WriteLine(" 2 - Azure SQL Database");
WriteLine(" 3 - Azure SQL Edge");
WriteLine();

Write("press a key: ");
ConsoleKey key = ReadKey().Key;
WriteLine();WriteLine();

if (key is ConsoleKey.D1 or ConsoleKey.NumPad1)
{
    builder.DataSource = "."; //Local SQL server 
    // @".\SQLEXPRESS"; // Local SQL Server with an instance name
}
else if (key is ConsoleKey.D2 or ConsoleKey.NumPad2)
{
    //Azure SQL database 
    builder.DataSource = "tcp:apps-services-book.database.windows.net,1433";
}
else if (key is ConsoleKey.D3 or ConsoleKey.NumPad3)
{
    //Azure SQL Edge
    builder.DataSource = "tcp:127.0.0.1,1433";
}
else
{
    WriteLine("No data source selected.");
    return;
}

//parou aqui

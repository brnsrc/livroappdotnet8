﻿using Microsoft.Data.SqlClient; //To use SqlConnectionStringBuilder
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
    builder.DataSource = ".\\SQLEXPRESS"; //Local SQL server 
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

WriteLine("Authenticate using:");
WriteLine(" 1 - Windows Integrated Security");
WriteLine(" 2 - SQL Login");
WriteLine();
Write("Press key: ");
key = ReadKey().Key;
WriteLine();WriteLine();
if (key is ConsoleKey.D1 or ConsoleKey.NumPad1)
{
    builder.IntegratedSecurity = true;
}else if(key is ConsoleKey.D2 or ConsoleKey.NumPad2)
{
    Write("Enter your SQL Server user ID: ");
    string? userId = ReadLine();
    if (string.IsNullOrEmpty(userId))
    {
        WriteLine("User ID cannot be empty or null.");
        return;
    }
    builder.UserID = userId;
    Write("Enter your password: ");
    string? password = ReadLine();
    if(string.IsNullOrEmpty(password))
    {        
        WriteLine("Password cannot be empty or null.");
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

DbContextOptionsBuilder<NorthwindDb> options = new();
options.UseSqlServer(builder.ConnectionString);

using(NorthwindDb db = new(options.Options)){
    Write("Enter a unit price: ");
    string? priceText = ReadLine();
    if (!decimal.TryParse(priceText, out decimal price))
    {
        WriteLine("You must enter a valid unit price.");
        return;
    }

    // We have to use var because we are projecting into an anonymous type.
    var products = db.Products.Where(p => p.UnitPrice > price)
        .Select(p => new {p.ProductId, p.ProductName, p.UnitPrice});

    WriteLine("-------------------------------------------------------");
    WriteLine("|{0,5}|{1,-35}|{2,8}|", "Id", "Name", "Price");
    WriteLine("-------------------------------------------------------");

    foreach (var p in products)
    {
        WriteLine("|{0,5}|{1,-35}|{2,8:C}|", 
            p.ProductId, p.ProductName, p.UnitPrice);
    }
    WriteLine("-------------------------------------------------------");
    WriteLine(products.ToQueryString());
    WriteLine();
    WriteLine($"Provider: {db.Database.ProviderName}");
    WriteLine($"Connection: {db.Database.GetConnectionString()}");

    

    
}
using Microsoft.Data.SqlClient; //To use SqlConnectionStringBuilder
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore; //GenerateCreateScript()
using Northwind.Models; //HierarchyDb, Person, Student

DbContextOptionsBuilder<HierarchyDb> options = new();
SqlConnectionStringBuilder builder = new();
builder.DataSource = ".\\SQLEXPRESS"; //"ServerName\instanceName" e.g. @".\sqlexpress"
builder.TrustServerCertificate = true;
builder.InitialCatalog = "HierarchyMapping";
builder.MultipleActiveResultSets = true;

//because we want to fail faster. Default is 15 seconds.
builder.ConnectTimeout = 3;

//If using SQL Server authentication
builder.UserID =  "sa";
builder.Password =  "bruno123";

options.UseSqlServer(builder.ConnectionString);
using (HierarchyDb db = new(options.Options))
{
    bool deleted = await db.Database.EnsureDeletedAsync();
    WriteLine($"Database deleted: {deleted}");

    bool created = await db.Database.EnsureCreatedAsync();
    WriteLine($"Database created: {created}");
    WriteLine(db.Database.GenerateCreateScript());

    if ((db.Employees is not null) && (db.Students is not null))
    {
        db.Students.Add(new Student{Name = "Connor Roy", Subject = "Politics"});
        db.Employees.Add(new Employee{Name = "Kerry Castellabate", 
            HireDate = DateTime.UtcNow});
        
        int result = db.SaveChanges();
        WriteLine($"{result} people added.");
    }

    if (db.Students is null || !db.Students.Any())
    {
        WriteLine("There are no students.");
    }
    else
    {
        foreach (Student student in db.Students)
        {
            WriteLine("{0} studies {1}", student.Name, student.Subject);
        }
    }

    if (db.Employees is null || !db.Employees.Any())
    {
        WriteLine("There are no employees.");
    }
    else
    {
        foreach (Employee employee in db.Employees)
        {
            WriteLine("{0} was hired on {1}", employee.Name, employee.HireDate);            
        }
    }
    
    if (db.People is null || !db.People.Any())
    {
        WriteLine("There are no people.");
    }
    else
    {
        foreach (Person person in db.People)
        {
            WriteLine("{0} has ID of {1}", person.Name, person.Id);
        }    
    }
}




using Microsoft.AspNetCore.Mvc;

namespace dotnet_api_test.Controllers;

[ApiController]
[Route("[controller]")]
public class SemesterController : ControllerBase
{
    private readonly ILogger<SemesterController> _logger;

    public SemesterController(ILogger<SemesterController> logger)
    {
        _logger = logger;
    }

    [HttpGet()]
    public IEnumerable<Semester> Get()
    {

        using var db = new SemesterContext();

        // Note: This sample requires the database to be created before running.
        Console.WriteLine($"Database path: {db.DbPath}.");

        // Create
        // Console.WriteLine("Inserting a new data");
        // db.Add(new Semester { Url = "http://datas.msdn.com/adonet" });
        // db.SaveChanges();

        // Read
        Console.WriteLine("Querying for a data");
        var data = db.Semesters
            .OrderBy(b => b.SemesterId)
            .ToList();
        return data;
    }
    [HttpPost()]
    public IEnumerable<Semester> Post([FromBody] Semester body)
    {

        using var db = new SemesterContext();

        // Note: This sample requires the database to be created before running.
        Console.WriteLine($"Database path: {db.DbPath}.");

        // Create
        Console.WriteLine("Inserting a new data");
        db.Add(body);
        db.SaveChanges();

        // Read
        Console.WriteLine("Querying for a data");
        var data = db.Semesters
            .OrderBy(b => b.SemesterId)
            .ToList();
        return data;
    }
    [HttpPut("{id}")]
    public IEnumerable<Semester> Delete([FromBody] Semester body, int id)
    {

        using var db = new SemesterContext();

        // Note: This sample requires the database to be created before running.
        Console.WriteLine($"Database path: {db.DbPath}.");

        // Update
        Console.WriteLine("Querying for a data");
        var data = db.Semesters
            .Find(id);
        data.Nama = body.Nama;
        db.SaveChanges();
        // Read
        Console.WriteLine("Querying for a data");
        var list = db.Semesters
            .OrderBy(b => b.SemesterId)
            .ToList();
        return list;
    }
    [HttpDelete("{id}")]
    public IEnumerable<Semester> Delete(int id)
    {

        using var db = new SemesterContext();

        // Note: This sample requires the database to be created before running.
        Console.WriteLine($"Database path: {db.DbPath}.");

        // Create
        Console.WriteLine("Inserting a new data");
        // Delete
        Console.WriteLine("Delete the data");
        db.Remove(new Semester { SemesterId = id });
        db.SaveChanges();

        // Read
        Console.WriteLine("Querying for a data");
        var data = db.Semesters
            .OrderBy(b => b.SemesterId)
            .ToList();
        return data;
    }
}
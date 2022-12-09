using Microsoft.AspNetCore.Mvc;

namespace dotnet_api_test.Controllers;

[ApiController]
[Route("[controller]")]
public class JurusanController : ControllerBase
{
    private readonly ILogger<JurusanController> _logger;

    public JurusanController(ILogger<JurusanController> logger)
    {
        _logger = logger;
    }

    [HttpGet()]
    public IEnumerable<Jurusan> Get()
    {

        using var db = new JurusanContext();

        // Note: This sample requires the database to be created before running.
        Console.WriteLine($"Database path: {db.DbPath}.");

        // Create
        // Console.WriteLine("Inserting a new data");
        // db.Add(new Jurusan { Url = "http://datas.msdn.com/adonet" });
        // db.SaveChanges();

        // Read
        Console.WriteLine("Querying for a data");
        var data = db.Jurusans
            .OrderBy(b => b.JurusanId)
            .ToList();
        return data;
    }
    [HttpPost()]
    public IEnumerable<Jurusan> Post([FromBody] Jurusan body)
    {

        using var db = new JurusanContext();

        // Note: This sample requires the database to be created before running.
        Console.WriteLine($"Database path: {db.DbPath}.");

        // Create
        Console.WriteLine("Inserting a new data");
        db.Add(body);
        db.SaveChanges();

        // Read
        Console.WriteLine("Querying for a data");
        var data = db.Jurusans
            .OrderBy(b => b.JurusanId)
            .ToList();
        return data;
    }
    [HttpPut("{id}")]
    public IEnumerable<Jurusan> Delete([FromBody] Jurusan body, int id)
    {

        using var db = new JurusanContext();

        // Note: This sample requires the database to be created before running.
        Console.WriteLine($"Database path: {db.DbPath}.");

        // Update
        Console.WriteLine("Querying for a data");
        var data = db.Jurusans
            .Find(id);
        data.Nama = body.Nama;
        data.Fakultas = body.Fakultas;
        db.SaveChanges();
        // Read
        Console.WriteLine("Querying for a data");
        var list = db.Jurusans
            .OrderBy(b => b.JurusanId)
            .ToList();
        return list;
    }
    [HttpDelete("{id}")]
    public IEnumerable<Jurusan> Delete(int id)
    {

        using var db = new JurusanContext();

        // Note: This sample requires the database to be created before running.
        Console.WriteLine($"Database path: {db.DbPath}.");

        // Create
        Console.WriteLine("Inserting a new data");
        // Delete
        Console.WriteLine("Delete the data");
        db.Remove(new Jurusan { JurusanId = id });
        db.SaveChanges();

        // Read
        Console.WriteLine("Querying for a data");
        var data = db.Jurusans
            .OrderBy(b => b.JurusanId)
            .ToList();
        return data;
    }
}
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace dotnet_api_test.Controllers;

[ApiController]
[Route("[controller]")]
public class MahasiswaController : ControllerBase
{
    private readonly ILogger<MahasiswaController> _logger;

    public MahasiswaController(ILogger<MahasiswaController> logger)
    {
        _logger = logger;
    }

    //TODO [HttpGet("WithSemester")]


    [HttpGet("WithJurusan")]
    public async Task<object?> GetWithJurusan()
    {
        try
        {
            HttpClient client = new HttpClient();
            using HttpResponseMessage response = await client.GetAsync("http://localhost:5192/Jurusan");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
            using var db = new MahasiswaContext();
            Console.WriteLine($"Database path: {db.DbPath}.");

            // Read
            Console.WriteLine("Querying for a data");
            var data = db.Mahasiswas
                .OrderBy(b => b.MahasiswaId)
                .ToList();
            var jurusan = JsonConvert.DeserializeObject<IEnumerable<Jurusan>>(responseBody);
            var result = data.Select(it => new { MahasiswaId = it.MahasiswaId, NIM = it.NIM, Nama = it.Nama, JurusanId = it.JurusanId, Jurusan = jurusan?.ToList().Find(j => j.JurusanId == it.JurusanId) }).ToList();
            return result;
            // return data;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
            return null;
        }
    }

    [HttpGet()]
    public IEnumerable<Mahasiswa> Get()
    {

        using var db = new MahasiswaContext();

        // Note: This sample requires the database to be created before running.
        Console.WriteLine($"Database path: {db.DbPath}.");

        // Create
        // Console.WriteLine("Inserting a new data");
        // db.Add(new Mahasiswa { Url = "http://datas.msdn.com/adonet" });
        // db.SaveChanges();

        // Read
        Console.WriteLine("Querying for a data");
        var data = db.Mahasiswas
            .OrderBy(b => b.MahasiswaId)
            .ToList();
        return data;
    }
    [HttpPost()]
    public IEnumerable<Mahasiswa> Post([FromBody] Mahasiswa body)
    {

        using var db = new MahasiswaContext();

        // Note: This sample requires the database to be created before running.
        Console.WriteLine($"Database path: {db.DbPath}.");

        // Create
        Console.WriteLine("Inserting a new data");
        db.Add(body);
        db.SaveChanges();

        // Read
        Console.WriteLine("Querying for a data");
        var data = db.Mahasiswas
            .OrderBy(b => b.MahasiswaId)
            .ToList();
        return data;
    }
    [HttpPut("{id}")]
    public IEnumerable<Mahasiswa> Delete([FromBody] Mahasiswa body, int id)
    {

        using var db = new MahasiswaContext();

        // Note: This sample requires the database to be created before running.
        Console.WriteLine($"Database path: {db.DbPath}.");

        // Update
        Console.WriteLine("Querying for a data");
        var data = db.Mahasiswas
            .Find(id);
        data.NIM = body.NIM;
        data.Nama = body.Nama;
        data.JurusanId = body.JurusanId;
        db.SaveChanges();
        // Read
        Console.WriteLine("Querying for a data");
        var list = db.Mahasiswas
            .OrderBy(b => b.MahasiswaId)
            .ToList();
        return list;
    }
    [HttpDelete("{id}")]
    public IEnumerable<Mahasiswa> Delete(int id)
    {

        using var db = new MahasiswaContext();

        // Note: This sample requires the database to be created before running.
        Console.WriteLine($"Database path: {db.DbPath}.");

        // Create
        Console.WriteLine("Inserting a new data");
        // Delete
        Console.WriteLine("Delete the data");
        db.Remove(new Mahasiswa { MahasiswaId = id });
        db.SaveChanges();

        // Read
        Console.WriteLine("Querying for a data");
        var data = db.Mahasiswas
            .OrderBy(b => b.MahasiswaId)
            .ToList();
        return data;
    }
}


public class Jurusan
{
    public int JurusanId { get; set; }
    public string? Nama { get; set; }
    public string? Fakultas { get; set; }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class MahasiswaContext : DbContext
{
    public DbSet<Mahasiswa> Mahasiswas { get; set; }

    public string DbPath { get; }

    public MahasiswaContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "mahasiswa.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}

public class Mahasiswa
{
    public int MahasiswaId { get; set; }
    public string NIM { get; set; }
    public string Nama { get; set; }
    public int JurusanId { get; set; }
}
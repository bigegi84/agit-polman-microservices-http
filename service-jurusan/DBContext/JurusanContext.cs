using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class JurusanContext : DbContext
{
    public DbSet<Jurusan> Jurusans { get; set; }

    public string DbPath { get; }

    public JurusanContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "jurusan.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}

public class Jurusan
{
    public int JurusanId { get; set; }
    public string Nama { get; set; }
    public string Fakultas { get; set; }
}
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class SemesterContext : DbContext
{
    public DbSet<Semester> Semesters { get; set; }

    public string DbPath { get; }

    public SemesterContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "semester.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}

public class Semester
{
    public int SemesterId { get; set; }
    public string Nama { get; set; }
}
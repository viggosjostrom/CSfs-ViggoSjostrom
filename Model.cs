using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class MyDbContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<User> Users { get; set; }

    public string DbPath { get; }

    public MyDbContext()
    {
        string folder = Environment.CurrentDirectory;
        DbPath = System.IO.Path.Join(folder, "CSfs-ViggoSjöström");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    public void ResetDatabase()
    {
        int postCount = 0;
        int blogCount = 0;
        int userCount = 0;
        
        Console.WriteLine();
        Console.WriteLine("Resetting the database...");
        foreach (var post in Posts)
        {
            Posts.Remove(post);
            postCount++;
        }
        Console.WriteLine($"Total deleted posts: {postCount}");

        foreach (var user in Users)
        {
            Users.Remove(user);
            userCount++;
        }
        Console.WriteLine($"Total deleted users: {userCount}");

        foreach (var blog in Blogs)
        {
            Blogs.Remove(blog);
            blogCount++;
        }
        Console.WriteLine($"Total deleted blogs: {blogCount}");

        SaveChanges();
        Console.WriteLine("Database reset completed.");
    }
}

public class Blog
{
    public int Id { get; set; }
    public string? Url { get; set; }
    public string? Name { get; set; }

    public List<Post> Posts { get; } = [];
}

public class User
{
    public int Id { get; set; }
    public string? Username { get; set; }

    public string? Password { get; set; }

    public List<Post> Posts { get; } = [];
}
public class Post
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public DateTime PublishedOn { get; set; }

    public int BlogId { get; set; }
    public Blog? Blog { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; } 
}
using CSfs_ViggoSjöström;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;
using System.Linq;


using MyDbContext? db = new();

Console.WriteLine($"SQLite DB Located at: {db.DbPath}");
Console.WriteLine();

string mainFolder = Environment.CurrentDirectory;
string BlogCSV = Path.Join(mainFolder, "Blog.csv");
string UserCSV = Path.Join(mainFolder, "User.csv");
string PostCSV = Path.Join(mainFolder, "Post.csv");

try
{
    using (var parser = new TextFieldParser(BlogCSV))
    {
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(",");

        while (!parser.EndOfData)
        {
            string[]? fields = parser.ReadFields();

            int id = int.Parse(fields[0]);
            string url = fields[1];
            string name = fields[2];

            var newBlog = new Blog
            {
                Id = id,
                Url = url,
                Name = name,
            };
            db.Blogs.Add(newBlog);
        }
        db.SaveChanges();
    }

    using (var parser = new TextFieldParser(UserCSV))
    {
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(",");

        while (!parser.EndOfData)
        {
            string[]? fields = parser.ReadFields();

            int id = int.Parse(fields[0]);
            string username = fields[1];
            string password = fields[2];

            var newUser = new User
            {
                Id = id,
                Username = username,
                Password = password,
            };
            db.Users.Add(newUser);
        }
        db.SaveChanges();
    }

    using (var parser = new TextFieldParser(PostCSV))
    {
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(",");

        while (!parser.EndOfData)
        {
            string[]? fields = parser.ReadFields();

            int id = int.Parse(fields[0]);
            string title = fields[1];
            string content = fields[2];
            DateTime publishedOn = DateTime.Parse(fields[3]);
            int blogId = int.Parse(fields[4]);
            int userId = int.Parse(fields[5]);

            var newPost = new Post
            {
                Id = id,
                Title = title,
                Content = content,
                PublishedOn = publishedOn,
                BlogId = blogId,
                UserId = userId

            };
            db.Posts.Add(newPost);
        }
        db.SaveChanges();
    }
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}

using var dbContext = new MyDbContext();

Console.WriteLine("Blogs:");
foreach (Blog? blog in dbContext.Blogs.Include(b => b.Posts).ThenInclude(p => p.User))
{
    Console.WriteLine($"- {blog.Name}");
    foreach (Post? post in blog.Posts)
    {
        Console.WriteLine($"  - {post.Title}");
        Console.WriteLine($"    - Content: {post.Content}");
        Console.WriteLine($"    - Author/Username: {post.User?.Username}");
    }
}

dbContext.ResetDatabase(); // kommentera ut för att ej tömma databasen på data



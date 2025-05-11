using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EFCore.Models;

namespace EFCore.DataStore;

public static class DatabaseSeeder
{
    public static void Seed(this DatabaseContext context)
    {
        if (!context.Posts.Any())
        {
            var fixedDate = new DateTime(2025, 5, 11, 23, 59, 59).ToUniversalTime();
            context.Posts.AddRange(
                new PostsTable
                {
                    Title = "First Post", 
                    Content = "Hello from the database!", 
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate
                },
                new PostsTable
                {
                    Title = "Second Post", 
                    Content = "Hello world!", 
                    CreatedAt = fixedDate,
                    UpdatedAt = fixedDate
                }
            );
            context.SaveChanges();
        }
    }
}
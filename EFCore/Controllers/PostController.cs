// using EFCore.DataStore;
// using EFCore.Models;
// using Microsoft.AspNetCore.Http.HttpResults;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
//
// namespace EFCore.Controllers;
//
// [ApiController]
// [Route("api/v1/[controller]")]
// public class PostController : ControllerBase
// {
//     private readonly DatabaseContext _context;
//     private readonly ILogger<PostController> _logger;
//
//     public PostController(DatabaseContext context, ILogger<PostController> logger)
//     {
//         _context = context;
//         _logger = logger;
//     }
//
//     // Create
//     [HttpPost]
//     public async Task<IActionResult> CreatePost(PostsTable newPost)
//     {
//         // Create new post
//         var currentDateTime = DateTime.UtcNow;
//         var newPostEntity = new PostsTable
//         {
//             Title = newPost.Title,
//             Content = newPost.Content,
//             UpdatedAt = currentDateTime,
//             CreatedAt = currentDateTime,
//         };
//         
//         // Try to add and save the new post
//         try
//         {
//             _context.Posts.Add(newPostEntity);
//             await _context.SaveChangesAsync();
//         }
//         catch (DbUpdateException)
//         {
//             return BadRequest();
//         }
//         
//         // Return created item
//         return Ok(newPostEntity);
//     }
//     
//     // Read
//     [HttpGet("{id}")]
//     public async Task<IActionResult> GetSpecificPost(int id)
//     {
//         // Fetch post (if post with provided id exist)
//         var result = await _context.Posts.FindAsync(id);
//         
//         // If post does not exist, return NotFound
//         if (result is null) return NotFound();
//         
//         // Post is found, output the data
//         return Ok(result);
//     }
//
//     [HttpGet]
//     public async Task<IActionResult> GetAllPosts()
//     {
//         // Find all posts
//         var result = await _context.Posts.ToListAsync();
//         
//         // Return all posts (empty list if no posts exist)
//         return Ok(result);
//     }
//
//     // Update
//     [HttpPut("{id}")]
//     public async Task<IActionResult> UpdatePost(int id, PostsTable newPost)
//     {
//         // Check if IDs match
//         if (id != newPost.Id) return BadRequest("Ids do not match");
//         
//         // find existing post
//         var existingPost = await _context.Posts.FindAsync(id);
//         if (existingPost is null) return NotFound();
//
//         // Only update specific fields
//         existingPost.Title = newPost.Title;
//         existingPost.Content = newPost.Content;
//         existingPost.UpdatedAt = DateTime.UtcNow;
//         
//         // try saving
//         try
//         {
//             // Update and return post
//             await _context.SaveChangesAsync();
//             return Ok(existingPost);
//         }
//         catch (DbUpdateConcurrencyException)
//         {
//             if (!_context.Posts.Any(e => e.Id == id)) return NotFound();
//             throw;
//         }
//     }
//
//     // Delete
//     [HttpDelete("{id}")]
//     public async Task<IActionResult> DeletePost(int id)
//     {
//         // Check is post exists
//         var existingPost = await _context.Posts.FindAsync(id);
//         if (existingPost is null) return NotFound();
//         
//         // If post exists, remove it
//         _context.Posts.Remove(existingPost);
//         await _context.SaveChangesAsync();
//         
//         // Return NoContent response because we removed the existing data
//         return NoContent();
//     }
// }
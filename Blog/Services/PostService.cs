using Blog.Data;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;
using SQLitePCL;
using Blog.Models;

namespace Blog.Services
{
    public class PostService
    {
        private readonly AppDbContext _context; //getting data from database
        public PostService(AppDbContext context) {  _context = context; }

        //Get all post service
        public async Task<List<PostResponse>> GetAllPost()
        {
            return await _context.Posts
               .Include(p => p.Author)
               .Include(p => p.Likes)
               .Include(p => p.Comments)  
               .Select(p => new PostResponse
                { 
                   Id = p.Id,
                   Title = p.Title,
                   Content = p.Content,
                   CreatedAt = p.CreatedAt,
                   AuthorUsername = p.Author != null ? p.Author.Username : null,
                   LikesCount = p.Likes.Count,
                   CommentsCount = p.Comments.Count
               }).ToListAsync();
        }

        public async Task<PostResponse?> GetPostById(int id)
        {
            var post = await _context.Posts
                .Include(p => p.Author)
                .Include(p => p.Likes)
                .Include(p => p.Comments)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (post == null) return null;

            return new PostResponse
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                CreatedAt = post.CreatedAt,
                AuthorUsername = post.Author != null ? post.Author.Username : null,
                LikesCount = post.Likes.Count,
                CommentsCount = post.Comments.Count
            };
        }

        public async Task<PostResponse> CreateAsync(CreatePostRequest request, int userId)
        {
            var post = new Post
            {
                Title = request.Title,
                Content = request.Content,
                UserId = userId,
                CreatedAt = DateTime.UtcNow
            };

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
 
            return await GetPostById(post.Id);
        }


        public async Task<bool> DeleteAsync(int id, int userId)
        {
            var post = await _context.Posts.FindAsync(id);

            if(post == null) return false;
            if(post.UserId != userId) return false;

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
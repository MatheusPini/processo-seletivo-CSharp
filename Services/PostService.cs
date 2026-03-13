using BlogMonolito.Data;
using BlogMonolito.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogMonolito.Services;

public interface IPostService
{
    Task<IEnumerable<Post>> GetAllAsync();
    Task<Post> CreateAsync(string title, string content, int userId);
    Task<Post?> UpdateAsync(int id, string title, string content, int userId);
    Task<bool> DeleteAsync(int id, int userId);
}

public class PostService : IPostService
{
    private readonly BlogDbContext _context;
    private readonly INotificationService _notificationService;

    public PostService(BlogDbContext context, INotificationService notificationService)
    {
        _context = context;
        _notificationService = notificationService;
    }

    public async Task<IEnumerable<Post>> GetAllAsync()
    {
        
        return await _context.Posts.Include(p => p.User).OrderByDescending(p => p.CreatedAt).ToListAsync();
    }

    public async Task<Post> CreateAsync(string title, string content, int userId)
    {
        var post = new Post { Title = title, Content = content, UserId = userId };
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
        
        
        
        await _notificationService.NotifyNewPostAsync(post.Title); 
        
        return post;
    }

    public async Task<Post?> UpdateAsync(int id, string title, string content, int userId)
    {
        
        var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id && p.UserId == userId);
        if (post == null) return null;

        post.Title = title;
        post.Content = content;
        await _context.SaveChangesAsync();
        return post;
    }

    public async Task<bool> DeleteAsync(int id, int userId)
    {
        
        var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id && p.UserId == userId);
        if (post == null) return false;

        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();
        return true;
    }
}
using BlogMonolito.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace BlogMonolito.Services;

public interface INotificationService
{
    Task NotifyNewPostAsync(string postTitle);
}

public class NotificationService : INotificationService
{
    private readonly IHubContext<NotificationHub> _hubContext;

    public NotificationService(IHubContext<NotificationHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task NotifyNewPostAsync(string postTitle)
    {
        await _hubContext.Clients.All.SendAsync("ReceiveNotification", $"Nova postagem publicada: {postTitle}");
    }
}
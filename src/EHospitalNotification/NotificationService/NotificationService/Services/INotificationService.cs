using NotificationService.Models;

namespace NotificationService.Services;

public interface INotificationService
{
    Task SendNotificationAsync(Notification notification);
}

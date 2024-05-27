using Tomnaia.DTO;

namespace Tomnaia.Interfaces
{
    public interface INotificationService
    {
        Task<List<NotificationResultDto>> GetCurrentUserNotificationsAsync();
        Task<NotificationResultDto> GetNotificationByIdAsync(string notificationId);
        Task<bool> DeleteAllNotificationAsync();
        Task<bool> DeleteNotificationByIdAsync(string notificationId);
    }
}

using ProductsCleanArch.Application.Common.Interfaces;
using ProductsCleanArch.Application.Notifications.Models;
using System.Threading.Tasks;

namespace ProductsCleanArch.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(MessageDto message)
        {
            return Task.CompletedTask;
        }
    }
}

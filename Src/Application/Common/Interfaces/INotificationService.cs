using ProductsCleanArch.Application.Notifications.Models;
using System.Threading.Tasks;

namespace ProductsCleanArch.Application.Common.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(MessageDto message);
    }
}

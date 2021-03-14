using System.Collections.Generic;
using Orchard.Repository.Notifications;

namespace Orchard.Repository.Interfaces
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
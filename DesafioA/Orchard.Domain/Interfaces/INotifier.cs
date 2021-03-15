using System.Collections.Generic;
using System.Linq;
using Orchard.Repository.Notifications;

namespace Orchard.Domain.Interfaces
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
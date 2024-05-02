using Questor.Domain.Aux.Interfaces;

namespace Questor.Domain.Aux.Service
{
    public class NotificationService : INotification
    {
        private List<Notification> _notifications;

        public NotificationService()
        {
            _notifications = new List<Notification>();
        }

        public void ClearNotification()
        {
            _notifications = new List<Notification>();
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }

        public bool HaveNotification()
        {
            return _notifications.Any();
        }
    }
}

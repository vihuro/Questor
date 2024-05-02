namespace Questor.Domain.Aux.Interfaces
{
    public interface INotification
    {
        bool HaveNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
        void ClearNotification();
    }
}

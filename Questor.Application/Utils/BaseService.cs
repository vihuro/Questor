using Questor.Domain.Aux;
using Questor.Domain.Aux.Interfaces;

namespace Questor.Application.Utils
{
    public abstract class BaseService
    {
        private readonly INotification _notification;

        protected BaseService(INotification notification)
        {
            _notification = notification;
        }
        protected bool IsValidOperation()
        {
            return !_notification.HaveNotification();
        }
        protected void Notify(string message)
        {
            _notification.Handle(new Notification(message));
        }
        protected void EntityIsValid<T>(T entity)
        {
            if (!entity.IsValid())
            {
                var errors = entity.GetValidationErros();
                foreach (var item in errors)
                {
                    Notify($"{item.MemberNames.FirstOrDefault()} - {item.ErrorMessage}");
                }
            }
        }
    }
}

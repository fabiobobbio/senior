using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Orchard.Domain.Interfaces;
using Orchard.Repository.Notifications;

namespace Orchard.Domain.Services
{
    public abstract class BaseService
    {
        private readonly INotifier _notifier;

        protected BaseService(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.ErrorMessage)
            {
                Notify(error.ToString());
            }
        }

        protected void Notify(string message)
        {
            _notifier.Handle(new Notification(message));
        }

        protected bool RunValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity<int, TE>
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid) return true;

            Notify(validator.ToString());

            return false;
        }
    }
}
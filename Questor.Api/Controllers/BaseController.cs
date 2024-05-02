using Microsoft.AspNetCore.Mvc;
using Questor.Application.Utils;
using Questor.Domain.Aux;
using Questor.Domain.Aux.Interfaces;

namespace Questor.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly INotification _notification;

        protected BaseController(INotification notification)
        {
            _notification = notification;
        }

        protected ActionResult InsertEntityResponse<T>(T entity)
        {
            if (IsValidOperation())
            {
                return Ok(new CustomResponse
                {
                    Sucess = true,
                    Data = entity
                });
            }
            return CustomResponseError();
        }
        protected ActionResult GetEntityResponse<T>(List<T> entity)
        {
            if (IsValidOperation())
            {
                return Ok(new CustomResponse
                {
                    Sucess = true,
                    Data = entity
                });
            }
            return CustomResponseError();
        }
        protected ActionResult GetEntityResponse<T>(T entity)
        {
            if (IsValidOperation())
            {
                return Ok(new CustomResponse
                {
                    Sucess = true,
                    Data = entity
                });
            }
            return CustomResponseError();
        }
        protected ActionResult CustomResponseError()
        {
            return BadRequest(new CustomResponse()
            {
                Sucess = false,
                Erros = _notification.GetNotifications().Select(x => x.Message)
            });
        }
        protected ActionResult CustomResponseError(string message)
        {
            _notification.Handle(new Notification(message));
            return BadRequest(new CustomResponse()
            {
                Sucess = false,
                Erros = _notification.GetNotifications().Select(x => x.Message)
            });
        }
        protected bool IsValidOperation()
        {
            return !_notification.HaveNotification();
        }

    }
}

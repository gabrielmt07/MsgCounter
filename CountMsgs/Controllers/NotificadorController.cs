using CountMsgs.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CountMsgs.Notificadores;
using System;
using CountMsgs.Services;

namespace Notificador.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NotificadorController : ControllerBase
    {
        private readonly INotificador _notificador;

        public NotificadorController(INotificador notificador)
        {
            _notificador = notificador;
        }

        [HttpGet]
        public string Get(int segundos)
        {
            return _notificador.Notifica(segundos);
        }
    }
}
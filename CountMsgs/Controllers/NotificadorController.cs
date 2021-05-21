using CountMsgs.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CountMsgs.Notificadores;
using System;

namespace Notificador.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NotificadorController : ControllerBase
    {
        private readonly MainContext _db;

        public NotificadorController(MainContext db)
        {
            _db = db;
        }

        [HttpGet]
        public string Get(int segundos)
        {
            Notificacao notificacao = new Notificacao();
            using (var command = _db.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = $"SELECT COUNT(*) as contador FROM Envio WHERE Data >= DATEADD(SECOND, {-segundos}, GETDATE())";
                _db.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    if(result.Read())
                    {
                        //notificacao.Registros = int.Parse(result["contador"].ToString());
                        //notificacao.TipoAlerta = notificacao.GrauAlerta();
                    }      
                    notificacao.TipoAlerta = 0;                  
                }
            }

            //notificacao.VerificaHora = notificacao.VerificaHorario(DateTime.Now);
            notificacao.VerificaHora = notificacao.VerificaHorario(new DateTime(2019,11,19,19,00,00));
            if (notificacao.VerificaHora)
            {
                return notificacao.EnviarAlerta();
            }
            return "SISTEMA EM OFF! FORA DO HORÁRIO COMERCIAL!";
        }
    }
}
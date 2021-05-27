using CountMsgs.Data;
using CountMsgs.Notificadores;
using Microsoft.EntityFrameworkCore;
using System;

namespace CountMsgs.Services.Imp
{
    public class Notificador : INotificador
    {
        private readonly MainContext _db;

        public Notificador(MainContext db)
        {
            _db = db;
        }

        public string Notifica(int segundos)
        {
            Notificacao notificacao = new Notificacao();
            using (var command = _db.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = $"SELECT COUNT(*) as contador FROM Envio WHERE Data >= DATEADD(SECOND, {-segundos}, GETDATE())";
                _db.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    if (result.Read())
                    {
                        notificacao.Registros = int.Parse(result["contador"].ToString());
                        notificacao.TipoAlerta = notificacao.GrauAlerta();
                    }
                    else
                        notificacao.TipoAlerta = 0;
                }
            }
            return notificacao.EnviarAlerta();
        }
    }
}

using CountMsgs.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Reflection;

namespace CountMsgs.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AcessarBd : ControllerBase
    {
        private readonly MainContext _db;

        public AcessarBd(MainContext db)
        {
            _db = db;
        }

        [HttpGet]
        public string Get(int segundos)
        {
            using (var command = _db.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = $"SELECT COUNT(*) as contador FROM Envio WHERE Data >= DATEADD(SECOND, {-segundos}, GETDATE())";
                _db.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    if(result.Read())
                    {
                        string msgCounter = result["contador"].ToString();
                        return msgCounter;
                    }
                    return "Tabela vazia";
                }
            }
            
        }
    }
}
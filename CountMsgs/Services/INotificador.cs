using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountMsgs.Services
{
    public interface INotificador
    {
        string Notifica(int segundos);
    }
}

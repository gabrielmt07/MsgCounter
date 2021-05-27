using System;

namespace CountMsgs.Notificadores
{
    public class Notificacao
    {
        public int Registros { get; set; }
        public int TipoAlerta { get; set; }
        public bool VerificaHora { get; set; }


        public int GrauAlerta()
        {
            if (Registros >= 100)
                return 1;

            else if (Registros < 100 && Registros >= 50)
                return 2;

            else
                return 3;
        }

        public string EnviarAlerta()
        {
            if (TipoAlerta == 0)
                return $"STATUS: ERRO! NÃO FOI POSSÍVEL ACESSAR O BANCO DE DADOS!";
            else if (TipoAlerta == 1)
                return $"STATUS: OK! Foram enviadas {Registros} mensagens na última hora.";
            else if (TipoAlerta == 2)
                return $"STATUS: ATENÇÃO! Foram enviadas {Registros} mensagens na última hora.";

            return $"STATUS: PROBLEMA! Foram enviadas {Registros} mensagens na última hora.";
        }

        public bool VerificaHorario(DateTime horario)
        {
            if (horario.Hour > 8 && horario.Hour < 19)
                return true;

            return false;
        }
    }
}

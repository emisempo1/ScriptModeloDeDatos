using System;

namespace Excepciones
{
    [Serializable]
    public class ExcepcionErrorDeSintaxisSql : ExcepcionGenerica
    {
        public const string message = "La consulta Sql esta mal, verifique la siguiente consulta ..  ";
        public ExcepcionErrorDeSintaxisSql(string msg) : base(message + msg) { }

    }
}

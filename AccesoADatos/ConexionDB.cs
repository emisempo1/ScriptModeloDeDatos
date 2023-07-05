using System;
using System.Data.SqlClient;

namespace AccesoADatos
{
    public class ConexionDB
    {
        public string conn_string { get; set; }
        public SqlConnection conectarbd = new SqlConnection();

        public ConexionDB()
        {
            conn_string = "Server = tcp:batferoperativa.database.windows.net, 1433; Initial Catalog = cadenasuministro_v1; Persist Security Info = False; User ID = lsempolis; Password = Cerrolargo10000 ; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
            //conn_string = "Server = tcp:batferoperativa.database.windows.net, 1433; Initial Catalog = cadenasuministro; Persist Security Info = False; User ID = lsempolis; Password = Cerrolargo10000 ; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
            conectarbd = new SqlConnection(conn_string);
        }

    }
}

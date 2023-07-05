using Dominio;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos.Repositorios
{
    public class TablaAvisosRepositorio
    {
        private readonly SqlConnection conexionBD;        

        public TablaAvisosRepositorio()
        {
            var conexion = new ConexionDB();
            this.conexionBD = conexion.conectarbd;            
        }

        public void Guardar(List<Compras_Batfer> lista)
        {
            string cadena = "INSERT INTO RPA_01_Tabla_Avisos (\n" +
                "[Documento_compras\r\nDocumento_compras\r\nDocumento_compras], \n" +
                "Fecha_Entrega, \n" +
                "Pais, \n" +
                "Proveedor_codigo, \n" +
                "Proveedor_nombre, \n" +
                "Aviso_15_dias, \n" +
                "Aviso_30_dias) \n" +
                "VALUES \n";
            
            lista.ForEach(item =>
            {                
                cadena += "('" +
                item.Documento_compras + "', \n'" +
                item.Fecha_Entrega.ToString("yyyy-MM-dd HH:mm:ss") + "', \n'" +
                item.Pais + "', \n'" +
                item.Proveedor_codigo + "', \n'" +
                item.Proveedor_nombre + "', \n'" +
                item.Aviso_15_dias.ToString("yyyy-MM-dd HH:mm:ss") + "', \n'" +
                item.Aviso_30_dias.ToString("yyyy-MM-dd HH:mm:ss") + "'), \n";
            });

            cadena = cadena.Substring(0, cadena.Length - 3) + ";";

            try
            {
                this.conexionBD.Open();
                SqlCommand comando = new SqlCommand(cadena, conexionBD);
                comando.ExecuteNonQuery();

                conexionBD.Close();

            }
            catch (SqlException e)
            {
                conexionBD.Close();

                if (e.Message.Split(' ')[0] == "Unknown")
                {
                    throw new ExcepcionErrorDeSintaxisSql(cadena);
                }

                throw new ExcepcionMotorBaseDeDatosCaido();
            }
        }

        public int CantidadTablaAvisos()
        {
            string cadena = "SELECT Count(*) FROM RPA_01_Tabla_Avisos;";

            try
            {
                this.conexionBD.Open();
                SqlCommand comando = new SqlCommand(cadena, conexionBD);
                SqlDataReader consulta = comando.ExecuteReader();

                int cantidad = 0;

                while (consulta.Read())
                {
                    if (!consulta.IsDBNull(0)) { cantidad = consulta.GetInt32(0); }
                }

                conexionBD.Close();
                return cantidad;

            }
            catch (SqlException e)
            {
                conexionBD.Close();

                if (e.Message.Split(' ')[0] == "Unknown")
                {
                    throw new ExcepcionErrorDeSintaxisSql(cadena);
                }

                throw new ExcepcionMotorBaseDeDatosCaido();
            }
        }
    }
}

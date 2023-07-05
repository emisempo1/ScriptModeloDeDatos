using Dominio;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos.Repositorios
{
    public class ComprasBatferRepositorio
    {
        private readonly SqlConnection conexionBD;        

        public ComprasBatferRepositorio()
        {
            var conexion = new ConexionDB();
            this.conexionBD = conexion.conectarbd;            
        }

        public List<Compras_Batfer> Obtener(int desde)
        {
            string cadena = "SELECT \n" +
                "Documento_compras, \n" +
                "Fecha_Entrega, \n" +
                "Pais, \n" +
                "Proveedor_codigo, \n" +
                "Proveedor_nombre, \n" +
                "Aviso_dias, \n" +
                "Aviso_15_dias, \n" +
                "Aviso_30_dias, \n" +
                "Responsable, \n" +
                "Cliente \n" +
                "FROM RPA_01_aux_COMPRAS_BATFER \n" +
                "ORDER BY Documento_compras \n" +
                "OFFSET " + desde + " ROWS;";

            try
            {
                this.conexionBD.Open();
                SqlCommand comando = new SqlCommand(cadena, conexionBD);
                SqlDataReader consulta = comando.ExecuteReader();

                List<Compras_Batfer> lista = new List<Compras_Batfer>();

                while (consulta.Read())
                {
                    Compras_Batfer compras_Batfer = new Compras_Batfer();

                    if (!consulta.IsDBNull(0)) { compras_Batfer.Documento_compras = consulta.GetDouble(0); }
                    if (!consulta.IsDBNull(1)) { compras_Batfer.Fecha_Entrega = consulta.GetDateTime(1); }
                    if (!consulta.IsDBNull(2)) { compras_Batfer.Pais = consulta.GetString(2); }
                    if (!consulta.IsDBNull(3)) { compras_Batfer.Proveedor_codigo = consulta.GetInt32(3); }
                    if (!consulta.IsDBNull(4)) { compras_Batfer.Proveedor_nombre = consulta.GetString(4); }
                    if (!consulta.IsDBNull(5)) { compras_Batfer.Aviso_dias = consulta.GetInt32(5); }
                    if (!consulta.IsDBNull(6)) { compras_Batfer.Aviso_15_dias = consulta.GetDateTime(6); }
                    if (!consulta.IsDBNull(7)) { compras_Batfer.Aviso_30_dias = consulta.GetDateTime(7); }
                    if (!consulta.IsDBNull(8)) { compras_Batfer.Responsable = consulta.GetString(8); }
                    if (!consulta.IsDBNull(9)) { compras_Batfer.Cliente = consulta.GetString(9); }

                    lista.Add(compras_Batfer);
                }

                conexionBD.Close();
                return lista;

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

        public int CantidadComprasBatfer()
        {
            string cadena = "SELECT Count(*) FROM RPA_01_aux_COMPRAS_BATFER;";

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

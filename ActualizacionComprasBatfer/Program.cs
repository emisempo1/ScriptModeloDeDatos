using AccesoADatos.Repositorios;
using Dominio;
using System;
using System.Collections.Generic;

namespace ActualizacionComprasBatfer
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            ComprasBatferRepositorio repoComprasBatfer = new ComprasBatferRepositorio();
            TablaAvisosRepositorio repoTablaAvisos = new TablaAvisosRepositorio();

            int cantidadCompras = repoComprasBatfer.CantidadComprasBatfer();
            int cantidadTablaAvisos = repoTablaAvisos.CantidadTablaAvisos();

            if (cantidadCompras > cantidadTablaAvisos)
            {
                try
                {
                    List<Compras_Batfer> lista = repoComprasBatfer.Obtener(cantidadTablaAvisos);

                    repoTablaAvisos.Guardar(lista);

                    Console.WriteLine("Se guardaron " + lista.Count + " registros.");

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }

        }

        
    }
}

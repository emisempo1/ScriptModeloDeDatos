using System;

namespace Dominio
{
    public class Compras_Batfer
    {
        public double Documento_compras { get; set; }
        public DateTime Fecha_Entrega { get; set; }
        public string Pais { get; set; }
        public int Proveedor_codigo { get; set; }
        public string Proveedor_nombre { get; set; }
        public int Aviso_dias { get; set; }
        public DateTime Aviso_15_dias { get; set; }
        public DateTime Aviso_30_dias { get; set; }
        public string Responsable { get; set; }
        public string Cliente { get; set; }
    }
}

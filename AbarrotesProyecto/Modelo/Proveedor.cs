using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbarrotesProyecto.Modelo
{
    public class Proveedor
    {
        public Int64 idProveedor { get; set; }
        public String NombreProveedor { get; set; }
        public String Direccion { get; set; }
        public String TelefonoPro { get; set; }
        public bool Estado { get; set; }



        public Proveedor() { }

        public Proveedor(Int64 idProveedor, String NombreProveedor, String Direccion, String TelefonoPro, String Calleemp, bool Estado)
        {
            this.idProveedor = idProveedor;
            this.NombreProveedor = NombreProveedor;
            this.Direccion = Direccion;
            this.TelefonoPro = TelefonoPro;
            this.Estado = Estado;
        }
    }
}

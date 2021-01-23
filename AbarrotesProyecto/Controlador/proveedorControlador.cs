using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BD_Comm_MySQL;
using System.Data;

namespace AbarrotesProyecto.Controlador
{
    public class proveedorControlador

    {
        private BDMSSQL mibd;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmpleadoControlador"/> class.
        /// </summary>
        /// <param name="_coneccion">The coneccion.</param>
        public proveedorControlador(string _coneccion)
        {
            mibd = new BDMSSQL(_coneccion);
        }

        public DataTable leerProveedor()
        {
            DataTable dt = mibd.LeerRegistrosEnmascarado("  Select * from Proveedor where Estado = 1");
            return dt;
        }
        public DataTable buscarProveedor(String Nombre)
        {
            DataTable dt = mibd.LeerRegistrosEnmascarado("select * from Proveedor where Estado = 1 and Nombreemp = '" + Nombre + "'");
            return dt;
        }

        public bool insertarProveedor(string _Nombreprov, string _direccion, string _telefono, bool _estado)
        {
            if (mibd.EjecutarSQL("insert into proveedor values('" + _Nombreprov + "','" + _direccion + "','" + _telefono + "','" + _estado + "');"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool modificarProveedor(string _Nombreprov, string _direccion, string _telefono, bool _estado, int _id)
        {
            if (mibd.EjecutarSQL("update Proveedor set NombreProveedor ='" + _Nombreprov + "', Direccion = '" + _direccion + "', TelefonoPro = '" + _telefono + "' where idProveedor = "+ _id ))

            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool eliminarProveedor(int idpro)
        {
            if (mibd.EjecutarSQL("update Proveedor set Estado = '" + 0 + "' where idProveedor =" + idpro))

            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

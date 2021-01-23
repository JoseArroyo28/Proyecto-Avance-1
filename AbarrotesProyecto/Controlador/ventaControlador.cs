using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD_Comm_MySQL;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AbarrotesProyecto.Controlador
{
    public class ventaControlador
    {
        private BDMSSQL mibd;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmpleadoControlador"/> class.
        /// </summary>
        /// <param name="_coneccion">The coneccion.</param>
        public ventaControlador(string _coneccion)
        {
            mibd = new BDMSSQL(_coneccion);
        }

        public DataTable leerVentas()
        {
            DataTable dt = mibd.LeerRegistrosEnmascarado(" SELECT * FROM Venta");
            return dt;
        }
        public DataTable llenacomboProducto()
        {
            DataTable dt = mibd.LeerRegistrosEnmascarado("select p.IdProducto, p.Nombrepro as Nombre_Producto from Producto as p");
            return dt;
        }
        public DataTable llenacmbEmpleado()
        {
            DataTable dt = mibd.LeerRegistrosEnmascarado("select idEmpleado, Nombreemp from Empleado");
            return dt;
        }
        public DataTable obtenerPrecio(int _id)
        {
            DataTable dt = mibd.LeerRegistrosEnmascarado("  Select CostoVenta from producto where idProducto = '" + _id + "'");
            return dt;
        }
        public DataTable obtenerId()
        {
            DataTable dt = mibd.LeerRegistrosEnmascarado("   SELECT idVenta, COUNT(*) AS Id_Venta FROM Venta GROUP BY idVenta HAVING COUNT(*) > 0 ORDER BY idVenta");
            return dt;
        }
        public bool insertarVenta(int _id,string _fecha, int _idProducto, int _idEmpleado,  double _montoTotal, int _cantidad)
        {
            if (mibd.EjecutarSQL("insert into Venta values('" + _id + "','" + _fecha + "','" + _idProducto + "','" + _idEmpleado + "','" + _montoTotal + "','" + _cantidad + "');"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable leerVentasrango(string fechaIncio, string fechaFin)
        {
            DataTable dt = mibd.LeerRegistrosEnmascarado(" select idVenta, Concat(NombrePro,' ', Marca, ' ', Neto) as Datos_pro, productoCantidad, p.CostoCompra, (productoCantidad* p.CostoCompra) as Total, v.Fecha from Venta as v inner join Producto as p on v.idProducto = p.idProducto where Fecha >= '"+ fechaIncio + "' and Fecha<='"+fechaFin+"'");
            return dt;
        }
    }
}

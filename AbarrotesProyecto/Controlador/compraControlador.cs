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
    public class compraControlador
    {


        private BDMSSQL mibd;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmpleadoControlador"/> class.
        /// </summary>
        /// <param name="_coneccion">The coneccion.</param>
        public compraControlador(string _coneccion)
        {
            mibd = new BDMSSQL(_coneccion);
        }

        public DataTable leerCompras()
        {
            DataTable dt = mibd.LeerRegistrosEnmascarado(" SELECT * FROM Compra");
            return dt;
        }
       
        public DataTable llenaCombo()
        {
            DataTable dt = mibd.LeerRegistrosEnmascarado("select p.IdProducto, p.Nombrepro as Nombre_Producto from Producto as p");
            return dt;
        }
        public DataTable llenacmbProveedor()
        {
            DataTable dt = mibd.LeerRegistrosEnmascarado("select idProveedor, NombreProveedor from Proveedor");
            return dt;
        }
        public bool insertarCompra(string _fecha, int _idProducto, int _idProveedor, int _cantidadProducto, double _montoTotal)
        {
            if (mibd.EjecutarSQL("insert into Compra values('" + _fecha + "','" + _idProducto + "','" + _idProveedor + "','" + _cantidadProducto + "','" + _montoTotal + "');"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable obtenerPrecio(int _id)
        {
            DataTable dt = mibd.LeerRegistrosEnmascarado("  Select CostoCompra from producto where IdProducto = '" + _id + "'");
            return dt;
        }
        public DataTable leercomprasRango(string _fechaInicio, string _fechaFin)
        {
            DataTable dt = mibd.LeerRegistrosEnmascarado(" select c.idVenta, concat (p.NombrePro,' ',p.Marca,' ', p.Neto) as Datos_producto , p.CostoCompra,p.CostoVenta, TotalProducto, fecha from Compra as c inner join Producto as p on c.idProducto = p.idProducto where Fecha >= '" + _fechaInicio+"' and Fecha<='" +_fechaFin+"'");
            return dt;
        }

    }
    
}

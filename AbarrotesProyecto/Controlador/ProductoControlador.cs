using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD_Comm_MySQL;
using System.Data;
namespace AbarrotesProyecto.Controlador
{
    public class ProductoControlador
    {
        private BDMSSQL mibd;
        public ProductoControlador(string _coneccion)
        {
            mibd = new BDMSSQL(_coneccion);
        }
        public DataTable leerProductos()
        {
            DataTable dt = mibd.LeerRegistrosEnmascarado(" SELECT * FROM Producto where Estado = 1");
            return dt;
        }
      /*  public DataTable leerProducto()
        {
            DataTable dt = mibd.LeerRegistrosEnmascarado("  Select idEmpleado, Nombreemp, ApellidoPemp, ApellidoMemp, Calleemp, Numeroemp, Coloniaemp,Telefonoemp from EMPLEADO where Estado = 1");
            return dt;
        }*/
        public DataTable productoedit(int _id)
        {
            DataTable dt = mibd.LeerRegistrosEnmascarado("  Select * from producto where idProducto = '" + _id + "'");
            return dt;
        }
        public bool insertarProducto(string _NombrePro, string _Marca, string _Neto, string _Caategoria, int _stock, bool _estado, byte[] _Foto, string _codigoBarra, double _precioCompra, double _precioVenta)
        {
            if (mibd.EjecutarSQL("insert into producto values('" + _NombrePro + "','" + _Marca + "','" + _Neto + "','" + _Caategoria + "','" + _stock + "','" + _estado + "','" + _Foto + "','" + _codigoBarra + "','" + _precioCompra + "','" + _precioVenta + "');"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ModificarEmpleado(string _NombrePro, string _Marca, string _Neto, string _Caategoria, int _stock, bool _estado, byte[] _Foto, string _codigoBarra, double _precioCompra, double _precioVenta)
        {
            if (mibd.EjecutarSQL("update producto set [NombrePro] ='" + _NombrePro + "', [Marca] = '" + _Marca + "', [Neto] = '" + _Neto + "', [Categoria] = '" + _Caategoria + "',[Stock]='" + _stock + "',[Estado]='" + _estado + "',[Imagen]='" + _Foto + "',[CodigoBarra] = '" + _codigoBarra + "',CostoCompra= '" + _precioCompra + "',CostoVenta = '" + _precioVenta))

            {
                return true;
            }
            else
            {
                return false;
            }
        }
       /* public bool compraProducto(int _id, int _cantidad)
        {
            if (mibd.EjecutarSQL("update producto set Stock = Stock +" + _cantidad+ " where idProducto ="+_id))

            {
                return true;
            }
            else
            {
                return false;
            }
        }*/
        public bool modificaStock(string _operacion,int _cantidad, int _id)
        {
            if (_operacion=="Compra")
            {
                if (mibd.EjecutarSQL("update producto set Stock = Stock +" + _cantidad + " where idProducto =" + _id))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (mibd.EjecutarSQL("update producto set Stock = Stock -" + _cantidad + " where idProducto =" + _id))
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
}

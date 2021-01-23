using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD_Comm_MySQL;
using System.Data;

namespace AbarrotesProyecto.Controlador
{
   public  class EmpleadoControlador
    {
        private BDMSSQL mibd;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmpleadoControlador"/> class.
        /// </summary>
        /// <param name="_coneccion">The coneccion.</param>
        public EmpleadoControlador(string _coneccion)
        {
            mibd = new BDMSSQL(_coneccion);
        }

        /// <summary>
        /// Leer todos los empleado.
        /// </summary>
        /// <returns>Lee a los Empleado que se encuentran en la base de datos</returns>
        public DataTable leerEmpleado()
        {
            DataTable dt = mibd.LeerRegistrosEnmascarado("  Select idEmpleado, Nombreemp, ApellidoPemp, ApellidoMemp, Calleemp, Numeroemp, Coloniaemp,Telefonoemp from EMPLEADO where Estado = 1");
            return dt;
        }
        public DataTable llenacmbEmpleado()
        {
            DataTable dt = mibd.LeerRegistrosEnmascarado("select idEmpleado, Nombreemp from Empleado");
            return dt;
        }
        public DataTable BuscaEMpleado(String Nombre)
        {
            DataTable dt = mibd.LeerRegistrosEnmascarado("select * from Empleado where Estado = 1 and Nombreemp = '" + Nombre + "'");
            return dt;
        }
        public bool InsertarEmpleado(string _Nombreemp, string _ApellidoPemp, string _ApellidoMemp, string _Calleemp, string _Numeroemp, string _coloniaemp, string _telefonoemp, string _contraseña, bool _Estado, string _correo)
        {
            if (mibd.EjecutarSQL("insert into empleado values('" + _Nombreemp + "','" + _ApellidoPemp + "','" + _ApellidoMemp + "','" + _Calleemp + "','" + _Numeroemp + "','" + _coloniaemp + "','" + _telefonoemp + "','" + _contraseña + "','" + _Estado + "','" + _correo + "');"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ModificarEmpleado(string _Nombreemp, string _ApellidoPemp, string _ApellidoMemp, string _Calleemp, string _Numeroemp, string _coloniaemp, string _telefonoemp, string _contraseña, bool _Estado, string _correo, int IdEmpleado)
        {
            if (mibd.EjecutarSQL("update empleado set Nombreemp ='" + _Nombreemp + "', ApellidoPemp = '" + _ApellidoPemp + "', ApellidoMemp = '" + _ApellidoMemp + "', Calleemp = '" + _Calleemp + "',Numeroemp='" + _Numeroemp + "',Coloniaemp='" + _coloniaemp + "',Telefonoemp='" + _telefonoemp + "',Contraseña = '" + _contraseña + "',Estado = '" + _Estado + "',Correo = '" + _correo + "' where IdEmpleado =" + IdEmpleado))

            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool EliminarEmpleado( int IdEmpleado)
        {
            if (mibd.EjecutarSQL("update empleado set Estado = '" + 0 + "' where IdEmpleado =" + IdEmpleado))

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

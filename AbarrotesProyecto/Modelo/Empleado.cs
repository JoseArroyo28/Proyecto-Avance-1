using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbarrotesProyecto.Modelo
{
    public class Empleado
    {
        public Int64 IdEmpleado { get; set; }
        public String Nombreemp { get; set; }
        public String ApellidoPemp { get; set; }
        public String ApellidoMemp { get; set; }
        public String Calleemp { get; set; }
        public String Numeroemp { get; set; }
        public String Coloniaemp { get; set; }
        public String Telefonoemp { get; set; }
        public Int64 IdRango { get; set; }
        public String Contraseña { get; set; }
        public String Correo { get; set; }



        public Empleado() { }

        public Empleado(Int64 IdEmpleado, String Nombreemp, String ApellidoPemp, String ApellidoMemp, String Calleemp, String Numeroemp, String Coloniaemp, String Telefonoemp, String Contraseña,String Correo)
            {
                this.IdEmpleado = IdEmpleado;
                this.Nombreemp = Nombreemp;
                this.ApellidoPemp = ApellidoPemp;
                this.ApellidoMemp = ApellidoMemp;
                this.Calleemp = Calleemp;
                this.Numeroemp = Numeroemp;
                this.Coloniaemp = Coloniaemp;
                this.Telefonoemp = Telefonoemp;
                this.IdRango = IdRango;
            this.Contraseña = Contraseña;
            this.Correo = Correo;
            }
        }
  
}

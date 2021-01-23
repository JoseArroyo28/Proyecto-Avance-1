using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD_Comm_MySQL;
using System.Data;
using System.Windows.Forms;

namespace AbarrotesProyecto.Controlador
{
    public class UsuarioControlador
    {
        private BDMSSQL mibd;
        public int Id = 0;
        public string Val = "";
        /// <summary>
        /// Initializes a new instance of the <see cref="UsuarioControlador"/> class.
        /// </summary>
        /// <param name="_coneccion">The coneccion.</param>
        public UsuarioControlador(string _coneccion)
        {
            mibd = new BDMSSQL(_coneccion);
        }
        public bool VerificarUsuario(string _usuario, string _Contraseña)
        {
            DataRow dr = mibd.Leer1Registro("select idEmpleado from Empleado where Nombreemp = '" + _usuario + "'and Contraseña='" + _Contraseña + "'and Estado = 1");

            if (dr == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

       
    }
}

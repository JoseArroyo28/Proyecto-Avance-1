using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbarrotesProyecto.Vistas
{
    public partial class verEmpleado : Form
    {
        public verEmpleado()
        {
            InitializeComponent();
            this.dgvverEmpleado.AutoGenerateColumns = false;
            
        }
        Controlador.EmpleadoControlador objempleado = new Controlador.EmpleadoControlador(Modelo.DataBase.cadconn);
        private void verEmpleado_Load(object sender, EventArgs e)
        {
            dgvverEmpleado.DataSource = objempleado.leerEmpleado();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Vistas.CUDempleado cUDempleado = new CUDempleado(this);
            cUDempleado.Show();
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            dgvverEmpleado.DataSource = objempleado.BuscaEMpleado(txtBuscar.Text);
        }

        private void dgvverEmpleado_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Modelo.Empleado empleado = new Modelo.Empleado();

            empleado.IdEmpleado = int.Parse(dgvverEmpleado.CurrentRow.Cells[0].Value.ToString());
            empleado.Nombreemp = dgvverEmpleado.CurrentRow.Cells[1].Value.ToString();
            empleado.ApellidoPemp = dgvverEmpleado.CurrentRow.Cells[2].Value.ToString();
            empleado.ApellidoMemp = dgvverEmpleado.CurrentRow.Cells[3].Value.ToString();
            empleado.Calleemp = dgvverEmpleado.CurrentRow.Cells[4].Value.ToString();
            empleado.Numeroemp = dgvverEmpleado.CurrentRow.Cells[5].Value.ToString();
            empleado.Coloniaemp = dgvverEmpleado.CurrentRow.Cells[6].Value.ToString();
            empleado.Telefonoemp = dgvverEmpleado.CurrentRow.Cells[7].Value.ToString();


          CUDempleado modificar = new CUDempleado(this, empleado, Convert.ToString(empleado.IdEmpleado));
           modificar.Show();
            this.Close();
        }

        private void dgvverEmpleado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

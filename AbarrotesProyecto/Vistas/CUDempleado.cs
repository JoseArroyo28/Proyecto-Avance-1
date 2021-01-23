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
    public partial class CUDempleado : Form
    {
        Controlador.EmpleadoControlador objempleado = new Controlador.EmpleadoControlador(Modelo.DataBase.cadconn);
        verEmpleado EMPLEADO;
        Modelo.Empleado MEMPLEADO;
        public CUDempleado(verEmpleado empleado)
        {
            InitializeComponent();
            EMPLEADO = empleado;
            lblTipo.Text = "Agregar";
            btnEliminar.Enabled = false;
        }
        string _id;
        public CUDempleado(verEmpleado empleado, Modelo.Empleado mempleado, string id)
        {
            InitializeComponent();
          lblTipo.Text = "Modificar";
           btnAgregar.Enabled = false;
            btnEliminar.Enabled = true;
           this._id = id;
            this.Text = "Modificar empleado";
            MEMPLEADO = mempleado;
            txtNombre.Text = mempleado.Nombreemp;
            txtApellidoP.Text = mempleado.ApellidoPemp;
            txtApellidoM.Text = mempleado.ApellidoMemp;
            txtCalle.Text = mempleado.Calleemp;
            txtNumero.Text = Convert.ToString(mempleado.Numeroemp);
            txtColonia.Text = mempleado.Coloniaemp;
            txtTelefono.Text = Convert.ToString(mempleado.Telefonoemp);
            txtCorreo.Text = mempleado.Correo;
            txtContraseña.Text = mempleado.Contraseña;
            EMPLEADO = empleado;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            verEmpleado verEmpleado = new verEmpleado();
            if (objempleado.InsertarEmpleado(txtNombre.Text, txtApellidoP.Text, txtApellidoM.Text, txtCalle.Text, txtNumero.Text, txtColonia.Text, (txtTelefono.Text), txtCorreo.Text, true,txtContraseña.Text))
                {
                    MessageBox.Show("Empleado registrado!!!");
                    this.Close();
                verEmpleado.Show();
            }
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            verEmpleado verEmpleado = new verEmpleado();
            if (lblTipo.Text == "Modificar")
            {
               if (objempleado.ModificarEmpleado(txtNombre.Text, txtApellidoP.Text, txtApellidoM.Text, txtCalle.Text, (txtNumero.Text), txtColonia.Text, (txtTelefono.Text), txtContraseña.Text, true,txtCorreo.Text, Convert.ToInt32(_id)))
                {
                    MessageBox.Show("Empleado Modificado");
                    this.Close();
                    verEmpleado.Show();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            verEmpleado verEmpleado = new verEmpleado();
            if (objempleado.EliminarEmpleado(Convert.ToInt32(_id)))
            {
                MessageBox.Show("Empleado Eliminado");
                this.Close();
                verEmpleado.Show();
            }
        }

       
    }
}

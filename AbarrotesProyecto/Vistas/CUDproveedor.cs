using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbarrotesProyecto
{
    public partial class CUDproveedor : Form
    {
        Controlador.proveedorControlador objProveedor = new Controlador.proveedorControlador(Modelo.DataBase.cadconn);
        verProveedor PROVEEDOR;
        Modelo.Proveedor MPROOVEDOR;
        public CUDproveedor()
        {
            InitializeComponent();
        }
        public CUDproveedor(verProveedor proveedor)
        {
            InitializeComponent();
            PROVEEDOR = proveedor;
            lblTipo.Text = "Agregar";
            btnEliminar.Enabled = false;
        }
        string _id;
        public CUDproveedor(verProveedor proveedor, Modelo.Proveedor mproveedor, string id)
        {
            InitializeComponent();
            lblTipo.Text = "Modificar";
            btnRegistrar.Enabled = false;
            btnEliminar.Enabled = true;
            this._id = id;
            this.Text = "Modificar empleado";
            MPROOVEDOR = mproveedor;
            txtNombre.Text = mproveedor.NombreProveedor;
            txtDireccion.Text = mproveedor.Direccion;
            txtTelefono.Text = mproveedor.TelefonoPro;
            PROVEEDOR = proveedor;
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (objProveedor.insertarProveedor(txtNombre.Text,txtDireccion.Text,txtTelefono.Text, true))
            {
                MessageBox.Show("Proveedor Ingresado Correctamente");
                this.Close();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (objProveedor.modificarProveedor(txtNombre.Text, txtDireccion.Text, txtTelefono.Text, true,int.Parse(_id)))
            {
                MessageBox.Show("Proveedor Modifica Correctamente");
                this.Close();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (objProveedor.eliminarProveedor( int.Parse(_id)))
            {
                MessageBox.Show("Proveedor Eliminado Correctamente");
                this.Close();
            }
        }
    }
}

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
    public partial class verProveedor : Form
    {
        public verProveedor()
        {
            InitializeComponent();
            this.dgvverProveedor.AutoGenerateColumns = false;
        }
        Controlador.proveedorControlador objProveedor = new Controlador.proveedorControlador(Modelo.DataBase.cadconn);
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CUDproveedor cUDproveedor = new CUDproveedor();
            cUDproveedor.Show();
            this.Close();
        }

        private void verProveedor_Load(object sender, EventArgs e)
        {
            dgvverProveedor.DataSource = objProveedor.leerProveedor();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvverProveedor.DataSource = objProveedor.buscarProveedor(txtBuscar.Text);
        }

        private void dgvverProveedor_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Modelo.Proveedor proveedor = new Modelo.Proveedor();

            proveedor.idProveedor = int.Parse(dgvverProveedor.CurrentRow.Cells[0].Value.ToString());
            proveedor.NombreProveedor = dgvverProveedor.CurrentRow.Cells[1].Value.ToString();
            proveedor.Direccion = dgvverProveedor.CurrentRow.Cells[2].Value.ToString();
            proveedor.TelefonoPro = dgvverProveedor.CurrentRow.Cells[3].Value.ToString();
            CUDproveedor modificar = new CUDproveedor(this, proveedor, Convert.ToString(proveedor.idProveedor));
            modificar.Show();
            this.Close();
        }
    }
}

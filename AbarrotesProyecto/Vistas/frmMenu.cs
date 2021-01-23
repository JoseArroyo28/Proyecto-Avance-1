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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (pnlMenu.Width == 215)
            {
                pnlMenu.Width = 80;
            }
            else
            {
                pnlMenu.Width = 215;
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            verProducto verProducto = new verProducto();
            verProducto.Show();
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            Vistas.Venta venta = new Vistas.Venta();
            venta.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            verProveedor verProveedor = new verProveedor();
            verProveedor.Show();
        }

        private void w_Click(object sender, EventArgs e)
        {
            compraProducto compra = new compraProducto();
            compra.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Vistas.verEmpleado verEmpleado = new Vistas.verEmpleado();
            verEmpleado.Show();
        }

        private void pnlMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void eeeeeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void itinerarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbarrotesProyecto.Vistas.intinerario intinerario = new Vistas.intinerario();
            intinerario.Show();
        }
    }
}

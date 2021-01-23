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

    public partial class compraProducto : Form
    {
        Controlador.compraControlador compraControlador = new Controlador.compraControlador(Modelo.DataBase.cadconn);
        Controlador.ProductoControlador producto = new Controlador.ProductoControlador(Modelo.DataBase.cadconn);

        public compraProducto()
        {
            InitializeComponent();
            txtFecha.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }

        private void compraProducto_Load(object sender, EventArgs e)
        {
            cmbProducto.DataSource= compraControlador.llenaCombo();
            cmbProveedor.DataSource = compraControlador.llenacmbProveedor();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
           if (compraControlador.insertarCompra(txtFecha.Text, Convert.ToInt32(cmbProducto.SelectedValue), Convert.ToInt32(cmbProveedor.SelectedValue.ToString()),Convert.ToInt32(numericUpDown1.Value.ToString()),Convert.ToInt64(txtTotal.Text)))
            {
                if (producto.modificaStock("Compra", Convert.ToInt32(numericUpDown1.Value.ToString()), Convert.ToInt32(cmbProducto.SelectedValue)))
                {
                    MessageBox.Show("Compra Se Ha Registrado Correctamente!!");
                }
            }
        }

        private void numericUpDown1_Scroll(object sender, ScrollEventArgs e)
        {
            
           // txtTotal.Text = "" + compraControlador.obtenerPrecio(cmbProducto.Text);
            
        }

        private void compraProducto_MouseMove(object sender, MouseEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = compraControlador.obtenerPrecio(Convert.ToInt32(cmbProducto.SelectedValue));
            txtTotal.Text = "" + (Convert.ToInt64(numericUpDown1.Value.ToString())* Convert.ToInt64(dt.Rows[0]["CostoCompra"]) );
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMenu form = new frmMenu();
            form.Show();
           // Vistas.
            /*Vistas.Form1 form1 = new Vistas.Form1();
            Vistas.*/
        }
    }
}

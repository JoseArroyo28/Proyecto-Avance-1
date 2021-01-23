using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace AbarrotesProyecto
{
    public partial class verProducto : Form
    {
        public verProducto()
        {
            InitializeComponent();
            this.dataGridView2.AutoGenerateColumns = false;
        }
        Controlador.ProductoControlador objProducto = new Controlador.ProductoControlador(Modelo.DataBase.cadconn);
        private void btnBuscar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CUDproducto dproducto = new CUDproducto(this);
            dproducto.Show();
            this.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            Modelo.Producto producto = new Modelo.Producto();
            
            DataTable dt = new DataTable();
           
            dt = objProducto.productoedit(int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString()));
            producto.idProduucto = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
            producto.nombrePro = dt.Rows[0]["NombrePro"].ToString();
            producto.marcaPro = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            producto.netoPro = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            producto.categoriaPro = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            producto.stockPro = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            producto.estadoPro = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            producto.imagenpro = (byte[])dt.Rows[0]["Imagen"];
            producto.codigobarraPro = dataGridView2.CurrentRow.Cells[8].Value.ToString();
            CUDproducto modificar = new CUDproducto(this, producto, Convert.ToString(producto.idProduucto));
            modificar.Show();
            this.Close();
        }

        private void verProducto_Load(object sender, EventArgs e)
        {
            dataGridView2.DataSource = objProducto.leerProductos();
        }
    }
}

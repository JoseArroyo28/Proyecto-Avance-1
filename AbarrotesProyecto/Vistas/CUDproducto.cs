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
    public partial class CUDproducto : Form
    {
        Controlador.ProductoControlador objProducto = new Controlador.ProductoControlador(Modelo.DataBase.cadconn);
        verProducto PRODUCTO;
        Modelo.Producto MPRODUCTO;
        private void CUDproducto_Load(object sender, EventArgs e)
        {

        }
     /*   public CUDproducto()
        {
            InitializeComponent();
        }*/
          public CUDproducto(verProducto producto)
            {
              InitializeComponent();
                PRODUCTO = producto;
                lblOpe.Text = "Agregar";
                btnEliminar.Enabled = false;
            }
            string _id;
            public CUDproducto(verProducto producto, Modelo.Producto mproducto, string id)
            {
                InitializeComponent();
                lblOpe.Text = "Modificar";
                btnAgregar.Enabled = false;
                btnEliminar.Enabled = true;
                this._id = id;
                this.Text = "Modificar producto";
                MPRODUCTO = mproducto;
                txtNombre.Text = mproducto.nombrePro;
                txtMarca.Text = mproducto.marcaPro;
                txtNeto.Text = mproducto.netoPro;
                cmbCategoria.Text = mproducto.categoriaPro;
                txtCodigoBarra.Text = mproducto.codigobarraPro;
               System.IO.MemoryStream ms = new System.IO.MemoryStream(mproducto.imagenpro);
                //pictureBox1.Image = Image.FromStream(ms);
        }





        private void btnAgregar_Click(object sender, EventArgs e)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
           pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            if (objProducto.insertarProducto(txtNombre.Text,txtMarca.Text,txtNeto.Text,cmbCategoria.Text,int.Parse(txtStock.Text),true,ms.GetBuffer(),txtCodigoBarra.Text,int.Parse(txtprecioCompra.Text), int.Parse(txtprecioVenta.Text)))
            {
                MessageBox.Show("Prodcuto registrado!!!");
                this.Close();
            }
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
             OpenFileDialog openFile = new OpenFileDialog();
              DialogResult rs = openFile.ShowDialog();
                  if (rs == DialogResult.OK)
                  {
                      pictureBox1.Image = Image.FromFile(openFile.FileName);
                  }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }
    }
}

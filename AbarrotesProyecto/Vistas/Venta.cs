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
    public partial class Venta : Form
    {
        Controlador.agregartxt agregartxt = new Controlador.agregartxt();
        public Venta()
        {
            DateTime.Now.ToString("DD/MM/YYYY");
            InitializeComponent();
            txtFecha.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }
        int contador = 0, _id= 0,contadorProductos =0;
        double total = 0;
        Controlador.ProductoControlador producto = new Controlador.ProductoControlador(Modelo.DataBase.cadconn);
        Controlador.EmpleadoControlador EmpleadoControlador = new Controlador.EmpleadoControlador(Modelo.DataBase.cadconn);
        Controlador.compraControlador compraControlador = new Controlador.compraControlador(Modelo.DataBase.cadconn);
        Controlador.ventaControlador ventaControlador = new Controlador.ventaControlador(Modelo.DataBase.cadconn);
        private void Venta_Load(object sender, EventArgs e)
        {
            cmbProducto.DataSource = compraControlador.llenaCombo();
            cmbEmpleado.DataSource = EmpleadoControlador.llenacmbEmpleado();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            int rowEscribir = dgvProductos.Rows.Count - 1;

            dgvProductos.Rows.Add(1);
            dgvProductos.Rows[rowEscribir].Cells[0].Value = cmbProducto.SelectedValue.ToString();
            dgvProductos.Rows[rowEscribir].Cells[1].Value = cmbProducto.Text;
            dgvProductos.Rows[rowEscribir].Cells[2].Value = numericUpDown1.Value.ToString();
            dgvProductos.Rows[rowEscribir].Cells[3].Value = txtMonto.Text;
            total += double.Parse(txtMonto.Text);
            txtTotal.Text = total.ToString();
            contadorProductos++;
        }

        private void Venta_MouseMove(object sender, MouseEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = ventaControlador.obtenerPrecio(Convert.ToInt32(cmbProducto.SelectedValue));
            txtMonto.Text = "" + (Convert.ToInt64(numericUpDown1.Value.ToString()) * Convert.ToInt64(dt.Rows[0]["CostoVenta"]));
            if (contadorProductos > 0)
                btnAceptar.Enabled = true;
            else
            {
                btnAceptar.Enabled = false;
                btnEliminar.Enabled = false;
            }
                
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = ventaControlador.obtenerId();

            contador = 1;
            
            while (contador == Convert.ToInt64(dt.Rows[contador-1]["idVenta"]))
            {
                contador++;
                if (Convert.ToInt64(dt.Rows[contador-1]["idVenta"]) == Convert.ToInt32(dt.Rows.Count))
                {

                    contador++;
                    break;
                }
                
            }
            _id = contador;
            while (contadorProductos >= 0)
            {

                //if (contadorProductos == 0) break;
                if (contadorProductos - 1 == 0)
                {
                    
                    if (ventaControlador.insertarVenta(_id, txtFecha.Text, Convert.ToInt32(dgvProductos.Rows[contadorProductos-1].Cells[0].Value), Convert.ToInt32(cmbEmpleado.SelectedValue), Convert.ToInt32(txtTotal.Text), Convert.ToInt32(dgvProductos.Rows[contadorProductos - 1].Cells[2].Value)))
                    {
                       // agregartxt.GenerarCodigoIntermedioExpresion(dgvProductos.Rows[contadorProductos - 1].Cells[2].Value.ToString());
                        if (producto.modificaStock("", Convert.ToInt32(dgvProductos.Rows[contadorProductos - 1].Cells[2].Value), Convert.ToInt32(dgvProductos.Rows[contadorProductos - 1].Cells[0].Value)))
                        contadorProductos--;
                    }
                    break;
                }
                else
                {
                    if (ventaControlador.insertarVenta(_id, txtFecha.Text, Convert.ToInt32(dgvProductos.Rows[contadorProductos - 1].Cells[0].Value), Convert.ToInt32(cmbEmpleado.SelectedValue), Convert.ToInt32(txtTotal.Text), Convert.ToInt32(dgvProductos.Rows[contadorProductos - 1].Cells[2].Value)))
                    {
                       // agregartxt.GenerarCodigoIntermedioExpresion(dgvProductos.Rows[contadorProductos - 1].Cells[2].Value.ToString());
                        if (producto.modificaStock("", Convert.ToInt32(dgvProductos.Rows[contadorProductos - 1].Cells[2].Value), Convert.ToInt32(dgvProductos.Rows[contadorProductos - 1].Cells[0].Value)))
                            contadorProductos--;
                    }
                }
                
            }
            MessageBox.Show("Venta Registrada Con Exito!!");
            dgvProductos.Rows.Clear();
            contadorProductos = 0;
            txtTotal.Clear();
            
            
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEliminar.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           
           total -=double.Parse( dgvProductos.CurrentRow.Cells[3].Value.ToString());
            txtTotal.Text = total.ToString();
           dgvProductos.Rows.Remove(dgvProductos.CurrentRow);
            contadorProductos--;
        }
    }
}

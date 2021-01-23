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
    public partial class intinerario : Form
    {
        Controlador.ventaControlador ventaControlador = new Controlador.ventaControlador(Modelo.DataBase.cadconn);
        Controlador.compraControlador compraControlador = new Controlador.compraControlador(Modelo.DataBase.cadconn);
        public intinerario()
        {
            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            string fecha1 = dtpFechaInicio.Value.Month+ "/"+dtpFechaInicio.Value.Day +"/"+dtpFechaInicio.Value.Year;
            string fecha2 = dtpfechaFin.Value.Month + "/" + dtpfechaFin.Value.Day + "/" + dtpfechaFin.Value.Year;

            if (cmbSeleccion.Text == "Venta")
            {
                dataGridView1.DataSource= ventaControlador.leerVentasrango(fecha1, fecha2);
            }
            else
            {
                dataGridView1.DataSource = compraControlador.leercomprasRango(fecha1, fecha2);
            }
        }
    }
}

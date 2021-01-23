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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Controlador.UsuarioControlador usuarioControlador = new Controlador.UsuarioControlador(Modelo.DataBase.cadconn);
            if (usuarioControlador.VerificarUsuario(txtUsuario.Text, txtContraseña.Text))
            {
                MessageBox.Show("Bienvenido " + txtUsuario.Text, "Aviso");
                frmMenu frmMenu = new frmMenu();
                frmMenu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Los datos son incorrectos...", "ERROR");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaFactCS.Logica;
using SistemaFactCS.Modelo;

namespace SistemaFactCS
{
    public partial class P_Login: Form
    {
        clsMensajes msg = new clsMensajes();
        private clsUsuarios usuario = new clsUsuarios();

        public P_Login()
        {
            InitializeComponent();
            btnMinimize.Visible = false;
            btnMinimize.Enabled = false;
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            M_SeleccionUsuario selectUsu = new M_SeleccionUsuario();
            selectUsu.Show();
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            usuario.usuario = txtUsuario.Text;
            usuario.clave = txtClave.Text;
            //Se verifican las credenciales del usurio y se asigna en el objeto el ID, tipo de cuenta y nombre
            usuario = UsuariosLogica.Instancia.verificarCredenciales(usuario);
            if (usuario.ID > 0)
            {
                M_Principal m_Principal = new M_Principal();
                m_Principal.usuario = usuario;
                usuario = null;
                m_Principal.Show();
                m_Principal.BringToFront();
                this.Close();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            msg.msgCerrarApp();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximize.Visible = false;
            btnMaximize.Enabled = false;
            btnMinimize.Enabled = true;
            btnMinimize.Visible = true;
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMinimize.Visible = false;
            btnMinimize.Enabled = false;
            btnMaximize.Visible = true;
            btnMaximize.Enabled = true;
        }
    }
}

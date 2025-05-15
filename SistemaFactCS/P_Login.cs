using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaFactCS.clases;
using SistemaFactCS.Logica;
using SistemaFactCS.Modelo;

namespace SistemaFactCS
{
    public partial class PLogin: Form
    {
        ClsMensajes _msg = new ClsMensajes();
        private ClsUsuarios _usuario = new ClsUsuarios();
        FormMovement _formMove = FormMovement.Instancia;

        public PLogin()
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
            _formMove.OpenSelectionForm(2);
            this.Dispose();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            _usuario.Usuario = txtUsuario.Text;
            _usuario.Clave = txtClave.Text;
            //Se verifican las credenciales del usuario y se asigna en el objeto el ID, tipo de cuenta y nombre
            _usuario = UsuariosLogica.Instancia.VerificarCredenciales(_usuario);
            if (_usuario.Id > 0)
            {
                _formMove.OpenParentForm(_usuario.Usuario);
                this.Dispose();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            _msg.MsgCerrarApp();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}

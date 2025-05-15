using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaFactCS.Modelo;
using System.Configuration;
using System.IO;
using SistemaFactCS.clases;

namespace SistemaFactCS
{
    public partial class MPrincipal: Form
    {
        ClsMensajes _msg = new ClsMensajes();
        FormMovement _formMove = FormMovement.Instancia;
        private Form _activeForm = null;
        internal ClsUsuarios Usuario = new ClsUsuarios();

        public MPrincipal()
        {
            InitializeComponent();
            btnMinimize.Visible = false;
            btnMinimize.Enabled = false;
        }

        internal void OpenCHildForm(Form childForm)
        {
            //Si hay algún form abierto lo cierra
            if (_activeForm != null)
                _activeForm.Close();
            //Muestra el nuevo form como el activo
            _activeForm = childForm;
            //se establece el formualrio como uncontrol,en vez de un form
            childForm.TopLevel = false;
            // se quita el borde del form
            childForm.FormBorderStyle = FormBorderStyle.None;
            // Se establece el tamaño del form
            childForm.Dock = DockStyle.Fill;
            //Se agrega el form al panel
            panelPestañaActual.Controls.Add(childForm);
            // Se establece el tag del panel como el form
            panelPestañaActual.Tag = childForm;
            //Se muestra el form frente a todo lo demás
            childForm.Show();
            childForm.BringToFront();
        }



        private void M_Principal_Load(object sender, EventArgs e)
        {
             if (Usuario != null)
            {
                lblUsuario.Text = $"Usuario: {Usuario.Usuario}";
            }
             string empresa = ConfigurationManager.AppSettings["Empresa"];
            lblNomEmpresa.Text = empresa;
            if (File.Exists(ConfigurationManager.AppSettings["Logo"]))
            {
                Image logo = Image.FromFile(ConfigurationManager.AppSettings["Logo"]);
                picLogo.Image = logo;
            }
            else
            {
                picLogo.Image = Image.FromFile(".\recursos\\ICO_Image.png");
            }

        }

        private void timAnimTitulo_Tick(object sender, EventArgs e)
        {
            if (lblNomPestaña.Left > 0)
            {
                lblNomPestaña.Left -= 10;
            }
            else
            {
                timAnimTitulo.Stop();
            }
        }

        private void btnPrincipal_Click(object sender, EventArgs e)
        {

        }

        private void HideSubmenu()
        {
            if (subMenuMant.Visible == true)
                subMenuMant.Visible = false;
        }

        private void ShowSubmenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                HideSubmenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnMantenimiento_Click(object sender, EventArgs e)
        {
            if (subMenuMant.Visible == false)
                ShowSubmenu(subMenuMant);
            else
                HideSubmenu();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            //Abre la pestaña de mantenimiento correspondiente y coloca su titulo en la parte superior
            _formMove.OpenCHildForm(new PUsuarios(), "Usuarios");
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            //Abre la pestaña de mantenimiento correspondiente y coloca su titulo en la parte superior
            _formMove.OpenCHildForm(new PClientes(), "Clientes");
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            lblNomPestaña.Text = "Proveedores";
            //Abre la pestaña de mantenimiento correspondiente y coloca su titulo en la parte superior
        }

        private void btnImpuestos_Click(object sender, EventArgs e)
        {
            lblNomPestaña.Text = "Impuestos";
            //Abre la pestaña de mantenimiento correspondiente y coloca su titulo en la parte superior
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            lblNomPestaña.Text = "Categorías";
            //Abre la pestaña de mantenimiento correspondiente y coloca su titulo en la parte superior
        }

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            lblNomPestaña.Text = "Marcas";
            //Abre la pestaña de mantenimiento correspondiente y coloca su titulo en la parte superior
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            lblNomPestaña.Text = "Productos";
            //Abre la pestaña de mantenimiento correspondiente y coloca su titulo en la parte superior
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            _msg.MsgCerrarApp();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximize.Visible = false;
            btnMaximize.Enabled = false;
            btnMinimize.Enabled = true;
            btnMinimize.Visible = true;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMinimize.Visible = false;
            btnMinimize.Enabled = false;
            btnMaximize.Visible = true;
            btnMaximize.Enabled = true;
        }
        private void btnHide_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Usuario.Equals(null);
            _formMove.OpenSelectionForm(1);
        }
    }
}

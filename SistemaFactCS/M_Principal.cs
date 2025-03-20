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

namespace SistemaFactCS
{
    public partial class M_Principal: Form
    {
        clsMensajes msg = new clsMensajes();
        private Form activeForm = null;
        internal clsUsuarios usuario = new clsUsuarios();

        public M_Principal()
        {
            InitializeComponent();
            btnMinimize.Visible = false;
            btnMinimize.Enabled = false;
        }

        private void openCHildForm(Form ChildForm)
        {
            //Si hay algún form abierto lo cierra
            if (activeForm != null)
                activeForm.Close();
            //Muestra el nuevo form como el activo
            activeForm = ChildForm;
            //se establece el formualrio como uncontrol,en vez de un form
            ChildForm.TopLevel = false;
            // se quita el borde del form
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            // Se establece el tamaño del form
            ChildForm.Dock = DockStyle.Fill;
            //Se agrega el form al panel
            panelPestañaActual.Controls.Add(ChildForm);
            // Se establece el tag del panel como el form
            panelPestañaActual.Tag = ChildForm;
            //Se muestra el form frente a todo lo demás
            ChildForm.Show();
            ChildForm.BringToFront();
        }



        private void M_Principal_Load(object sender, EventArgs e)
        {
             if (usuario != null)
            {
                lblUsuario.Text = $"Usuario: {usuario.usuario}";
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
            lblNomPestaña.Text = "Usuarios";
            //Abre la pestaña de mantenimiento correspondiente
            openCHildForm(new P_Usuarios());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            lblNomPestaña.Text = "Clientes";
            //Abre la pestaña de mantenimiento correspondiente
            openCHildForm(new P_Clientes());
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            lblNomPestaña.Text = "Proveedores";
            //Abre la pestaña de mantenimiento correspondiente
        }

        private void btnImpuestos_Click(object sender, EventArgs e)
        {
            lblNomPestaña.Text = "Impuestos";
            //Abre la pestaña de mantenimiento correspondiente
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            lblNomPestaña.Text = "Categorías";
            //Abre la pestaña de mantenimiento correspondiente
        }

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            lblNomPestaña.Text = "Marcas";
            //Abre la pestaña de mantenimiento correspondiente
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            lblNomPestaña.Text = "Productos";
            //Abre la pestaña de mantenimiento correspondiente
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            msg.msgCerrarApp();
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
            usuario.Equals(null);
            M_SeleccionUsuario selectUsu = new M_SeleccionUsuario();
            selectUsu.Show();
            selectUsu.BringToFront();
            this.Close();
        }
    }
}

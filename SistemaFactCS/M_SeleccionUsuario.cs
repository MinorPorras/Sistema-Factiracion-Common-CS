using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Windows.Media;
using Guna.UI2.WinForms;
using SistemaFactCS.Logica;
using System.Runtime.Remoting.Channels;
using System.Data.Design;

namespace SistemaFactCS
{
    public partial class M_SeleccionUsuario: Form
    {
        //Propiedades
        UsuariosLogica usuLog = new UsuariosLogica();
        DataTable dt = new DataTable();
        int cont = 0;
        clsMensajes msg = new clsMensajes();

        public M_SeleccionUsuario()
        {
            InitializeComponent();
            btnMinimize.Enabled = false;
            btnMinimize.Visible = false;
        }

        private void M_SeleccionUsuario_Load(object sender, EventArgs e)
        {
            dt = usuLog.CargarUsuarios(dt);
            if (dt.Rows.Count > 0 )
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CrearBoton(flpUsuarios, dr.ItemArray[1].ToString(), Convert.ToInt32(dr.ItemArray[0]), dr.ItemArray[2].ToString());
                }
            }
        }

        private void CrearBoton(FlowLayoutPanel flow, string nombre, int tag, string colorT)
        {
            List<string> splitRGB = colorT.Split(',').ToList();
            byte r = Convert.ToByte(splitRGB[0]);
            byte g = Convert.ToByte(splitRGB[1]);
            byte b = Convert.ToByte(splitRGB[2]);

            Guna2Button btn = new Guna2Button();

            btn.Name = $"btnUsu{cont}";
            btn.Size = new Size(100, 60);
            btn.Tag = tag;
            btn.Text = nombre;
            btn.Font = flow.Font;
            btn.FillColor = System.Drawing.Color.FromArgb( r, g, b);
            btn.HoverState.ForeColor = System.Drawing.Color.CornflowerBlue;
            btn.HoverState.FillColor = System.Drawing.Color.FromArgb(r, g, b);
            btn.Margin = new Padding(7, 15, 7, 0);
            btn.Dock = DockStyle.Bottom;

            //Se vincula el evento de click con el método creado
            btn.Click += BotonUsu_Click; 

            flpUsuarios.Controls.Add(btn);
            cont++;
        }
        private void BotonUsu_Click(object sender, EventArgs e)
        {
            Guna2Button btnClick = sender as Guna2Button;
            P_Login p_Login = new P_Login();
            p_Login.Show();
            p_Login.Select();
            p_Login.txtUsuario.Text = btnClick.Text;
            this.Hide();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            msg.msgCerrarApp();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
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

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMinimize.Visible = false;
            btnMinimize.Enabled = false;
            btnMaximize.Visible = true;
            btnMaximize.Enabled = true;
        }
    }
}

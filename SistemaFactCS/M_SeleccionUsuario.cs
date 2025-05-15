using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using SistemaFactCS.Logica;
using SistemaFactCS.clases;

namespace SistemaFactCS
{
    public partial class MSeleccionUsuario: Form
    {
        //Propiedades
        private readonly UsuariosLogica _usuLog = new UsuariosLogica();
        private DataTable _dt;
        private int _cont;
        private readonly ClsMensajes _msg = new ClsMensajes();
        private readonly FormMovement _formMovement = FormMovement.Instancia;

        public MSeleccionUsuario()
        {
            _dt = new DataTable();
            InitializeComponent();
            btnMinimize.Enabled = false;
            btnMinimize.Visible = false;
        }

        private void M_SeleccionUsuario_Load(object sender, EventArgs e)
        {
            _dt = _usuLog.CargarBtnUsuarios(_dt);
            if (_dt.Rows.Count <= 0) return;
            foreach (DataRow dr in _dt.Rows)
            {
                CrearBoton(flpUsuarios, dr.ItemArray[1].ToString(), Convert.ToInt32(dr.ItemArray[0]), dr.ItemArray[2].ToString());
            }
        }

        private void CrearBoton(FlowLayoutPanel flow, string nombre, int tag, string colorT)
        {
            List<string> splitRgb = colorT.Split(',').ToList();
            byte r = Convert.ToByte(splitRgb[0]);
            byte g = Convert.ToByte(splitRgb[1]);
            byte b = Convert.ToByte(splitRgb[2]);

            Guna2Button btn = new Guna2Button();

            btn.Name = $"btnUsu{_cont}";
            btn.Size = new Size(120, 60);
            btn.Tag = tag;
            btn.Text = nombre;
            btn.Font = flow.Font;
            btn.FillColor = Color.FromArgb( r, g, b);
            btn.HoverState.ForeColor = Color.CornflowerBlue;
            btn.HoverState.FillColor = Color.FromArgb(r, g, b);
            btn.Margin = new Padding(7, 15, 7, 0);
            btn.Dock = DockStyle.Bottom;

            //Se vincula el evento de click con el método creado
            btn.Click += BotonUsu_Click; 

            flpUsuarios.Controls.Add(btn);
            _cont++;
        }
        private void BotonUsu_Click(object sender, EventArgs e)
        {
            if (sender is Guna2Button btnClick) _formMovement.OpenLoginForm(btnClick.Text);
            this.Hide();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            _msg.MsgCerrarApp();
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Compilation;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using SistemaFactCS.Logica;
using SistemaFactCS.clases;
using SistemaFactCS.Modelo;


namespace SistemaFactCS
{
    public partial class PUsuarios: Form
    {
        private Timer _searchTimer;
        DataTable _dt = new DataTable();
        FormMovement _formMove = FormMovement.Instancia;
        UsuariosLogica _usuLog = UsuariosLogica.Instancia;

        public PUsuarios()
        {
            InitializeComponent();
            InicializarTimer();
        }

        private void P_Usuarios_Load(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void InicializarTimer()
        {
            _searchTimer = new Timer();
            //Medio segundo de intervalo
            _searchTimer.Interval = 100;
            _searchTimer.Tick += searchTimer_Tick;
        }

        private void searchTimer_Tick(object sender, EventArgs e)
        {
            _searchTimer.Stop();
            Refrescar();
        }

        private void Refrescar()
        {
            try
            {
                Task.Run(() =>
                {
                    dgvUsuarios.Invoke((MethodInvoker)delegate
                    {
                        DataTable dt = new DataTable();
                        dt = _usuLog.CargarUsuarios(dt, txtBuscarUsuario.Text);
                        if (dt.Rows.Count > 0)
                        {
                            mnuAcciones.Enabled = false;
                            BindingSource bs = new BindingSource();
                            bs.DataSource = dt;
                            mnuAcciones.Enabled = true;
                            dgvUsuarios.DataSource = bs;
                        }
                        else
                        {
                            dgvUsuarios.DataSource = null;
                        }
                    });
                });
                txtBuscarUsuario.Select();
            }
            catch
            {
                MessageBox.Show(@"Error al cargar los usuarios", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUsuarios_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //int selectedRowIndex = -1;
            //if (dgvUsuarios.SelectedRows.Count > 0)
            //{
            //    selectedRowIndex = dgvUsuarios.Rows[dgvUsuarios.SelectedRows[0].Index].Index;
            //}
            //for (int i = 0; i < dgvUsuarios.Columns.Count - 1; i++)
            //{
            //    dgvUsuarios.Columns[i].ReadOnly = true;
            //    switch (dgvUsuarios.Columns[i].Name)
            //    {
            //        case "ID":
            //            dgvUsuarios.Columns[i].Visible = false;
            //            break;
            //        case "Código":
            //            dgvUsuarios.Columns[i].HeaderText = "Codigo";
            //            dgvUsuarios.Columns[i].Width = 70;
            //            break;
            //        case "Usuario":
            //            dgvUsuarios.Columns[i].HeaderText = "Usuario";
            //            dgvUsuarios.Columns[i].Width = 300;
            //            break;
            //        case "Clave":
            //            dgvUsuarios.Columns[i].Visible = false;
            //            break;
            //        case "Tipo":
            //            dgvUsuarios.Columns[i].HeaderText = "Tipo";
            //            dgvUsuarios.Columns[i].Width = 150;
            //            break;
            //        case "Color":
            //            dgvUsuarios.Columns[i].HeaderText = "Color";
            //            dgvUsuarios.Columns[i].Width = 70;
            //            break;
            //    }
            //}
            //foreach (DataGridViewRow row in dgvUsuarios.Rows)
            //{
            //    if (row.Cells[5].Value != null)
            //    {
            //        string[] col = row.Cells[5].Value.ToString().Split(',');
            //        if (col.Length == 3)
            //        {
            //            byte r = Convert.ToByte(col[0]);
            //            byte g = Convert.ToByte(col[1]);
            //            byte b = Convert.ToByte(col[2]);
            //            row.Cells[5].Style.BackColor = Color.FromArgb(r, g, b);
            //            row.Cells[5].Style.ForeColor = Color.FromArgb(r, g, b);
            //            row.Cells[5].Style.SelectionBackColor = Color.FromArgb(r, g, b);
            //            row.Cells[5].Style.SelectionForeColor = Color.FromArgb(r, g, b);
            //        }
            //        if (int.TryParse(row.Cells[4].Value.ToString(), out int val))
            //        {
            //            if (val == 0)
            //            {
            //                row.Cells[4].Value = "Administrador";
            //            }
            //            else if (val == 1)
            //            {
            //                row.Cells[4].Value = "Cajero";
            //            }
            //            else
            //            {
            //                row.Cells[4].Value = "NA";
            //            }
            //        }

            //    }
            //    dgvUsuarios.ColumnHeadersDefaultCellStyle.Font = new Font("Noto Sans Georgian", 12, FontStyle.Bold);
            //    dgvUsuarios.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //    dgvUsuarios.DefaultCellStyle.Font = new Font("Noto Sans Georgian", 11);
            //    dgvUsuarios.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    dgvUsuarios.AutoResizeColumnHeadersHeight();
            //    if (selectedRowIndex >= 0 && selectedRowIndex < dgvUsuarios.Rows.Count)
            //    {
            //        dgvUsuarios.Rows[selectedRowIndex].Selected = true;
            //        dgvUsuarios.FirstDisplayedScrollingRowIndex = selectedRowIndex;
            //    }
            //}
        }

        private void txtBuscarUsuario_TextChanged(object sender, EventArgs e)
        {
            if (_searchTimer == null) return;
            _searchTimer.Stop();
            _searchTimer.Start();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            _formMove.OpenCHildForm(new EUsuario(), "Usuarios");
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show($@"Se eliminará el usuario {dgvUsuarios.SelectedRows[0].Cells[3].Value.ToString()}",
                @"Eliminar usuario",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            if (result != DialogResult.OK) return;
            var u = new ClsUsuarios
            {
                Id = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells[0].Value),
                Usuario = dgvUsuarios.SelectedRows[0].Cells[3].Value.ToString()
            };
            _usuLog.Eliminar(u);
            Refrescar();
        }
    }
}

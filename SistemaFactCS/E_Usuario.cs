using System;
using System.Drawing;
using System.Windows.Forms;
using SistemaFactCS.clases;
using SistemaFactCS.Logica;
using SistemaFactCS.Modelo;


namespace SistemaFactCS
{
    public partial class EUsuario: Form
    {
        private readonly FormMovement _formMove = FormMovement.Instancia;
        private string _colorUsuario;
        readonly ClsMensajes _msg = new ClsMensajes();
        readonly UsuariosLogica _usuLog = UsuariosLogica.Instancia;
        

        public EUsuario()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            _formMove.OpenCHildForm(new PUsuarios(), "Usuarios");
        }

        private void E_Usuario_Load(object sender, EventArgs e)
        {

        }

        private bool Validar()
        {
            if (string.IsNullOrEmpty(txtCodigoUsuario.Text) && string.IsNullOrEmpty(txtUsuario.Text) && cbxTipo.SelectedIndex < 0 && string.IsNullOrEmpty(_colorUsuario))
            {
                btnAgregarUsuario.Enabled = false;
                return false;
            }
            else
            {
                if (swtSinclave.Checked == false && string.IsNullOrEmpty(txtClave.Text))
                {
                    btnAgregarUsuario.Enabled = false;
                    return false;
                }
            }
            btnAgregarUsuario.Enabled = true;
            return true;
        }
        private void btnCol_Click(object sender, EventArgs e)
        {
            try
            {
                if (colorDialogUsuario.ShowDialog() == DialogResult.OK)
                {
                    int r = colorDialogUsuario.Color.R;
                    int g = colorDialogUsuario.Color.G;
                    int b = colorDialogUsuario.Color.B;
                    btnCol.FillColor = Color.FromArgb(r, g, b);
                    _colorUsuario = $"{r},{g},{b}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _colorUsuario = string.Empty;
            }
            finally
            {
                Validar();
            }
        }

        private void txtCodigoUsuario_TextChanged(object sender, EventArgs e)
        {
            Validar();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            Validar();
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            Validar();
        }

        private void cbxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Validar();
        }

        private void btnAutoCod_Click(object sender, EventArgs e)
        {
            txtCodigoUsuario.Text = _usuLog.BuscarSiguienteCod();
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;
            ClsUsuarios usuario = new ClsUsuarios
            {
                Codigo = txtCodigoUsuario.Text,
                Usuario = txtUsuario.Text,
                Clave = swtSinclave.Checked ? string.Empty : txtClave.Text,
                Tipo = cbxTipo.SelectedIndex,
                Color = _colorUsuario
            };
            if (!_usuLog.Agregar(usuario)) return;
            _msg.Mensaje("Usuario agregado correctamente", "Inserción correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _formMove.OpenCHildForm(new PUsuarios(), "Usuarios");
        }
    }
}

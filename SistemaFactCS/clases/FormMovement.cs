using System.Drawing;
using System.Windows.Forms;

namespace SistemaFactCS.clases
{
    public class FormMovement
    {
        private static FormMovement _instancia;
        private static MSeleccionUsuario _instanciaInicio;
        private static MPrincipal _instanciaPrincipal;
        private static PLogin _instanciaLogin;
        private Form _activeForm;
        MPrincipal _mPrincipal;
        PLogin _pLogin;

        public static FormMovement Instancia => _instancia ?? (_instancia = new FormMovement());

        public static MSeleccionUsuario InstanciaInicio()
        {
            return _instanciaInicio ?? (_instanciaInicio = new MSeleccionUsuario());
        }

        private static MPrincipal InstanciaPrincipal()
        {
            return _instanciaPrincipal ?? (_instanciaPrincipal = new MPrincipal());
        }

        private static PLogin InstanciaLogin()
        {
            return _instanciaLogin ?? (_instanciaLogin = new PLogin());
        }

        public void OpenSelectionForm(int from)
        {
            MSeleccionUsuario formSelection = InstanciaInicio();
            formSelection.Show();
            formSelection.BringToFront();
            switch (from)
            {
                case 1://Se regresa desde el menu principal
                    InstanciaPrincipal().Dispose();
                    _instanciaPrincipal = null;
                    InstanciaLogin().Dispose();
                    _instanciaLogin = null;
                    break;
                case 2: //Se regresa desde el login
                    InstanciaLogin().Dispose();
                    _instanciaLogin = null;
                    break;
            }
            _activeForm = null;
        }

        public void OpenParentForm(string usuario)
        {
            _mPrincipal = InstanciaPrincipal();
            _mPrincipal.Usuario.Usuario = usuario;
            _mPrincipal.Show();
            _mPrincipal.BringToFront();
        }

        public void OpenLoginForm(string usuario)
        {
            _pLogin = InstanciaLogin();
            _pLogin.txtUsuario.Text = usuario;
            _pLogin.Show();
            _pLogin.BringToFront();
        }

        public void OpenCHildForm(Form childForm, string text)
        {
            //Si hay algún form abierto lo cierra
            _activeForm?.Close();
            //Muestra el nuevo form como el activo
            _activeForm = childForm;
            //se establece el formualrio como uncontrol,en vez de un form
            childForm.TopLevel = false;
            // se quita el borde del form
            childForm.FormBorderStyle = FormBorderStyle.None;
            // Se establece el tamaño del form
            childForm.Dock = DockStyle.Fill;
            //Se agrega el form al panel
            _mPrincipal.panelPestañaActual.Controls.Add(childForm);
            // Se establece el tag del panel como el form
            _mPrincipal.panelPestañaActual.Tag = childForm;
            //Se muestra el form frente a todo lo demás
            childForm.Show();
            childForm.BringToFront();
            MostrarTitulo(_mPrincipal, text);
        }

        private void MostrarTitulo(MPrincipal form, string text)
        {
            Label titulo = form.lblNomPestaña;
            titulo.Visible = false;
            titulo.Text = text;
            titulo.Location = new Point(70, 0);
            titulo.Visible = true;
            form.timAnimTitulo.Start();
        }
    }
}

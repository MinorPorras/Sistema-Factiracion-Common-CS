using System;
using System.Collections.Generic;
using System.Data.Design;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFactCS
{
    class clsMensajes
    {
        internal DialogResult Result { get; set; }
        internal DialogResult mensaje(string texto, string titulo, MessageBoxButtons btn, MessageBoxIcon ico)
        {
            Result = MessageBox.Show(texto, titulo, btn, ico);
            return Result;
        }

        internal DialogResult msgGuardar()
        {
            MessageBoxButtons btn = MessageBoxButtons.OKCancel;
            string message = "¿Desea guardar los cambios?";
            string title = "Confirmar guardado de cambios";
            Result = MessageBox.Show(message, title, btn);
            return Result;
        }

        internal void msgCerrarApp()
        {
            MessageBoxButtons btn = MessageBoxButtons.OKCancel;
            string message = "¿Desea cerrar la aplicación?";
            string title = "Cierre de la aplicación";
            Result = MessageBox.Show(message, title, btn, MessageBoxIcon.Exclamation);
            if (Result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        internal void msgError(string texto)
        {
            MessageBox.Show(texto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal void msgDatoAlmacenado()
        {
            MessageBoxButtons btn = MessageBoxButtons.OK;
            string message = "Dartos almacenados correctamente";
            string title = "Guardado exitoso";
            MessageBox.Show(message, title, btn, MessageBoxIcon.Information);
        }

        internal void msgDatoEliminado()
        {
            MessageBoxButtons btn = MessageBoxButtons.OK;
            string message = "Datos dados de baja correctamente";
            string title = "Baja de elementos";
            MessageBox.Show(message, title, btn, MessageBoxIcon.Information);
        }

        internal void msgRestart()
        {
            MessageBoxButtons btn = MessageBoxButtons.OKCancel;
            string message = "Acción realizada exisamente, para reflejar los cambios correctamente se debe de reiniciar la app. ¿Desea reiniciar la aplicación?";
            string title = "Aplicación de configuraciones";
            Result = MessageBox.Show(message, title, btn, MessageBoxIcon.Asterisk);
            if (Result == DialogResult.OK)
            {
                Application.Restart();
            }
        }
    }
}

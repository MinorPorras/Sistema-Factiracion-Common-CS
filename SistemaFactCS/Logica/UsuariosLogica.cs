using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using SistemaFactCS.Modelo;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Data;

namespace SistemaFactCS.Logica
{
    internal class UsuariosLogica : clsCONEXION
    {
        private static UsuariosLogica _instancia = null;
        private clsMensajes msg = new clsMensajes();
        private DataTable dt = new DataTable(); 

        public UsuariosLogica()
        {
        }

        public static UsuariosLogica Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new UsuariosLogica();
                }
                return _instancia;
                
            }
        }

        public clsUsuarios verificarCredenciales(clsUsuarios obj)
        {
            clsUsuarios respuesta = new clsUsuarios();
            if (obj != null) 
            { 
                if (Connected())
                {
                    string consulta = "SELECT ID, tipo FROM usuario WHERE usuario = @usuario AND clave = @clave";
                    using (SQLiteCommand cmd = new SQLiteCommand(consulta, db))
                    {
                        cmd.Parameters.AddWithValue("@usuario", obj.usuario.ToString());
                        cmd.Parameters.AddWithValue("@clave", obj.clave.ToString());
                        dt = CargarTabla(cmd);
                        if (dt.Rows.Count <= 0)
                        {
                            msg.mensaje("El usuario y constraseña no son correctos", "Error de inicio de sesión", System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Disconnected();
                        }
                        else
                        {
                            Disconnected();
                            if (int.TryParse(dt.Rows[0].ItemArray[0].ToString(), out int ID))
                            {
                                respuesta.ID = ID;
                                if (int.TryParse(dt.Rows[0].ItemArray[1].ToString(), out int tipo))
                                {
                                    respuesta.usuario = obj.usuario;
                                    respuesta.tipo = tipo;
                                    return respuesta;

                                }
                            }
                        }
                    }
                }
            }
            return respuesta;
        }

        public DataTable CargarUsuarios(DataTable tabla)
        {
            tabla = new DataTable();
            string consulta = "SELECT ID, usuario, color FROM usuario";
            SQLiteCommand cmd = new SQLiteCommand(consulta);
            tabla = CargarTabla(cmd);
            return tabla;
        }

        public void Agregar()
        {

        }

        public void Eliminar()
        {

        }

        public void Actualizar()
        {

        }
    }
}

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
    internal class UsuariosLogica : ClsConexion
    {
        private static UsuariosLogica _instancia = null;
        private ClsMensajes _msg = new ClsMensajes();
        private DataTable _dt = new DataTable(); 

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

        public ClsUsuarios VerificarCredenciales(ClsUsuarios obj)
        {
            ClsUsuarios respuesta = new ClsUsuarios();
            if (obj != null) 
            { 
                if (Connected())
                {
                    string consulta = "SELECT ID, tipo FROM usuario WHERE usuario = @usuario AND clave = @clave";
                    using (SQLiteCommand cmd = new SQLiteCommand(consulta, Db))
                    {
                        cmd.Parameters.AddWithValue("@usuario", obj.Usuario.ToString());
                        cmd.Parameters.AddWithValue("@clave", obj.Clave.ToString());
                        _dt = CargarTabla(cmd);
                        if (_dt.Rows.Count <= 0)
                        {
                            _msg.Mensaje("El usuario y constraseña no son correctos", "Error de inicio de sesión", System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Disconnected();
                        }
                        else
                        {
                            Disconnected();
                            if (int.TryParse(_dt.Rows[0].ItemArray[0].ToString(), out int id))
                            {
                                respuesta.Id = id;
                                if (int.TryParse(_dt.Rows[0].ItemArray[1].ToString(), out int tipo))
                                {
                                    respuesta.Usuario = obj.Usuario;
                                    respuesta.Tipo = tipo;
                                    return respuesta;

                                }
                            }
                        }
                    }
                }
            }
            return respuesta;
        }

        public DataTable CargarBtnUsuarios(DataTable tabla)
        {
            tabla = new DataTable();
            string consulta = "SELECT ID, usuario, color FROM usuario";
            SQLiteCommand cmd = new SQLiteCommand(consulta);
            tabla = CargarTabla(cmd);
            return tabla;
        }

        public DataTable CargarUsuarios(DataTable tabla, string buscar)
        {
            try
            {
                _dt.Clear();
                string consulta = "SELECT u.ID, u.codigo AS 'Código', u.usuario AS 'Usuario', u.clave AS 'Clave', u.tipo As 'Tipo', u.color AS 'Color' FROM usuario u ";
                SQLiteCommand cmd;
                if (buscar.Length > 0)
                {
                    string buscarLike = $"%{buscar}%";
                    consulta += " WHERE codigo LIKE @buscar OR usuario LIKE @buscar ORDER BY u.codigo ASC";
                    cmd = new SQLiteCommand(consulta);
                    cmd.Parameters.AddWithValue("@buscar", buscarLike);
                }
                else
                {
                    consulta += " ORDER BY u.codigo ASC";
                    cmd = new SQLiteCommand(consulta);
                }
                tabla = CargarTabla(cmd);
                return tabla;
            }
            catch (Exception ex)
            {
                _msg.Mensaje($"Error al cargar los usuarios: {ex.Message}", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabla = null;
                return tabla;
            }
        }

        public string BuscarSiguienteCod()
        {
            return ObtenerCods("usuario", "ID", "AutoCodUsuario");
        }

        public bool Agregar(ClsUsuarios u)
        {
            if (Connected())
            {
                if (u != null)
                {
                    try
                    {
                        _dt.Clear();
                        string consulta = "INSERT INTO usuario (codigo, usuario, clave, tipo, color) VALUES (@codigo, @usuario, @clave, @tipo, @color)";
                        SQLiteCommand cmd = new SQLiteCommand(consulta, Db);
                        {
                            cmd.Parameters.AddWithValue("@codigo", u.Codigo);
                            cmd.Parameters.AddWithValue("@usuario", u.Usuario);
                            cmd.Parameters.AddWithValue("@clave", u.Clave);
                            cmd.Parameters.AddWithValue("@tipo", u.Tipo);
                            cmd.Parameters.AddWithValue("@color", u.Color);
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                return true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _msg.Mensaje($"Error al agregar el usuario: {ex.Message}", "Error de inserción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    _msg.Mensaje("No se ha ingresado un usuario válido", "Error de ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return false;
        }

        public bool Eliminar(ClsUsuarios u)
        {
            if (Connected())
            {
                if (u.Id >= 0)
                {
                    try
                    {
                        _dt.Clear();
                        var consulta = new StringBuilder().Append(@"DELETE FROM usuario WHERE id = @id").ToString();
                        var cmd = new SQLiteCommand(consulta, Db);
                        cmd.Parameters.AddWithValue("@id", u.Id);
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            return true;
                        }
                    }
                    catch (Exception e)
                    {
                        _msg.MsgError(new StringBuilder().Append("Ocurrió un error al eliminar el elemento: ")
                            .Append(e.Message)
                            .ToString());
                        return false;
                    }
                }
                else
                {
                    _msg.MsgError("Ocurrió un error al eliminar el elemento: El identificador en menor o igual a 0");
                    return false;
                }
            }
            else
            {
                _msg.MsgError("Error de conexión con la base de datos: La base de datos no está conectada o no se encuentra");
                return false;
            }

            return false;
        }

        public void Actualizar()
        {

        }
    }
}

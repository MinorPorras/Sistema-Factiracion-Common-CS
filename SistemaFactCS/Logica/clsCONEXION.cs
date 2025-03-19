using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Data.SQLite;
using System.Security.Cryptography;

namespace SistemaFactCS
{
    internal class clsCONEXION
    {
        //String de conexión
        private string conn;
        //Conexión con la db
        protected SQLiteConnection db;
        private readonly DataTable dt = new DataTable();

        //Cariable de uso de las propiedades
        private int idUsuActual;
        private string nomUsuActual;
        private bool isAdmin;
        private string consulta;

        private clsMensajes msg = new clsMensajes();

        protected bool Connected()
        {
            try
            {
                conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
                if (conn != null)
                {
                    db = new SQLiteConnection(conn);
                    if (db.State == ConnectionState.Closed)
                    {
                        db.Open();
                        return true;
                    }
                }
                else
                {
                    msg.msgError("No se encontró la cadena de conexión con al base de datos, favor revisar el estado de la conexión");
                }
                return false;
            }
            catch (Exception ex)
            {
                msg.msgError($"Error al conectarse a la base de datos, por favor revise la conexión actual. Error: {ex.Message}");
                return false;
            }
        }

        protected bool Disconnected()
        {
            try
            {
                if (db != null && db.State == ConnectionState.Open)
                {
                    db.Close();
                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                msg.msgError($"Error al desconectarse de la base de datos, por favor revise la conexión actual. Error: {ex.Message}");
                return false;
            }
        }

        internal DataTable CargarTabla(SQLiteCommand cmd)
        {
            try
            {
                if (Connected())
                {
                    dt.Clear();
                    using (cmd)
                    {
                        cmd.Connection = db;
                        using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                {
                    Disconnected();
                    msg.msgError($"Error al cargar la tabla. Error: {ex.Message}");
                    return dt;
                }
            }
            Disconnected();
            return dt;
        }
    }
}

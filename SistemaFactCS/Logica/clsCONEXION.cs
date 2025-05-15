using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace SistemaFactCS
{
    internal class ClsConexion
    {
        //String de conexión
        private string _conn;
        //Conexión con la db
        protected SQLiteConnection Db;
        private readonly DataTable _dt = new DataTable();

        //Cariable de uso de las propiedades
        private int _idUsuActual;
        private string _nomUsuActual;
        private bool _isAdmin;
        private string _consulta;

        private ClsMensajes _msg = new ClsMensajes();

        protected bool Connected()
        {
            try
            {
                _conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
                if (_conn != null)
                {
                    Db = new SQLiteConnection(_conn);
                    if (Db.State == ConnectionState.Closed)
                    {
                        Db.Open();
                        return true;
                    }
                }
                else
                {
                    _msg.MsgError("No se encontró la cadena de conexión con al base de datos, favor revisar el estado de la conexión" + Db.State + _conn);
                }
                return false;
            }
            catch (Exception ex)
            {
                _msg.MsgError($"Error al conectarse a la base de datos, por favor revise la conexión actual. Error: {ex.Message}");
                return false;
            }
        }

        protected bool Disconnected()
        {
            try
            {
                if (Db != null && Db.State == ConnectionState.Open)
                {
                    Db.Close();
                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                _msg.MsgError($"Error al desconectarse de la base de datos, por favor revise la conexión actual. Error: {ex.Message}");
                return false;
            }
        }

        internal DataTable CargarTabla(SQLiteCommand cmd)
        {
            try
            {
                if (Connected())
                {
                    _dt.Clear();
                    using (cmd)
                    {
                        cmd.Connection = Db;
                        using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                        {
                            da.Fill(_dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                {
                    Disconnected();
                    _msg.MsgError($"Error al cargar la tabla. Error: {ex.Message}");
                    return _dt;
                }
            }
            Disconnected();
            return _dt;
        }

        internal string GetAppSetting(string key)
        {
            string value = ConfigurationManager.AppSettings.Get(key);
            return value;
        }

        internal string ObtenerCods(string tabla, string atributo, string config)
        {
            List<int> lista = new List<int>();
            string codActual = "0";
            try
            {
                //Se limpia la tabla, y se hace la consulta, añadiendo cada ID a la lista
                _dt.Clear();
                _consulta = $"SELECT {atributo} FROM {tabla}";
                using (SQLiteCommand cmd = new SQLiteCommand(_consulta))
                {
                    CargarTabla(cmd);
                    //SI hay una fila o más en la tabla se llena la lista
                    if (_dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in _dt.Rows)
                        {
                            if (int.TryParse(row[atributo].ToString(), out int cod))
                            {
                                lista.Add(cod);
                            }
                        }
                    }
                    else
                    {
                        //Si no se carga ningúnID solo se devuelve el número 1 dentro de la lista, ya que es el primero código que se creara
                        lista.Add(1);
                    }
                }

                //Se ordena la lista
                lista.Sort();
                //Se obtiene el número de digitos deseado dentro del config de esta tabla
                int numConfig = Convert.ToInt32(GetAppSetting(config));

                int codigoDisponible = 1;
                foreach (int codigo in lista)
                {
                    //Si el código = codigo disponible se aumenta en uno porque este ya extiste en la base de datos
                    if (codigo == codigoDisponible)
                    {
                        codigoDisponible++;
                    }
                    else if (codigo > codigoDisponible) { 
                        //Si el código es mayor que el codigo disponible, este habrá encontrado el siguiente código a usar
                        //Si va 1, 2, 4; al llegar al codigoDIsponible = 3 el valor de codigo será 4, por lo que 3 es el siguiente código disponible
                        break;
                    }
                }
                codActual = codigoDisponible.ToString($"D{numConfig}");
            }
            catch (Exception ex)
            {
                //EN caso de error se desconecta y muestra un mensaje infromando un error para luego devolver un string vacío
                Disconnected();
                _msg.MsgError($"Error al cargar la lista. Error: {ex.Message}");
                return "";
            }
            Disconnected();
            return codActual;
        }
    }
}

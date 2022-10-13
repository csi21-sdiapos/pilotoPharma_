using Npgsql;

namespace PilotoPharma.Models.Conexiones
{
    public class ConexionPostgreSQL
    {

        //MÉTODOS
        public NpgsqlConnection GeneraConexion(string host, string port, string db, string user, string pass)
        {
            System.Console.WriteLine("\n\n\t[INFORMACIÓN-GeneraPostgreSQL-GeneraConexion] Entra en GeneraConexion\n");

            //Se crea una nueva conexión y la cadena con los datos de conexión.
            NpgsqlConnection conexion = new NpgsqlConnection();
            var datosConexion = "Server=" + host + "; Port=" + port + "; User Id=" + user + "; Password=" + pass + "; Database=" + db;
            //var datosConexion = "Server=localhost; Port=5432; User Id=postgres; Password=pr0f3s0r; Database=EjemploInicial";
            System.Console.WriteLine(datosConexion);
            var estado = string.Empty;

            if (!string.IsNullOrWhiteSpace(datosConexion))
            {
                try
                {
                    conexion = new NpgsqlConnection(datosConexion);
                    conexion.Open();
                    //Se obtiene el estado de conexión para informarlo por consola
                    estado = conexion.State.ToString();
                    System.Console.WriteLine("\n\n\t[INFORMACIÓN-GeneraPostgreSQL-GeneraConexion] Estado conexión: " + estado + "\n");
                }
                catch (Exception e)
                {
                    System.Console.WriteLine("\n\n\t[ERROR-conexionPostgresql-generaConexion] Error al crear conexión:" + e + "\n");
                    conexion.Close();
                }
            }

            return conexion;

        }

        public void Close(NpgsqlConnection conexion)
        {
            conexion.Close();
        }

    }
}

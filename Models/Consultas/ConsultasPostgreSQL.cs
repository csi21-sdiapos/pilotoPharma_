using Npgsql;
using PilotoPharma.Models.Conexiones;
using PilotoPharma.Models.DTOs;
using PilotoPharma.Models.ToDTOs;
using PilotoPharma.Util;

namespace PilotoPharma.Models.Consultas
{
    public class ConsultasPostgreSQL
    {

        // MÉTODOS

        /****************************************** CONSULTAS SELECT *******************************************/
        public static List<CatalogoDTO> ConsultaSelectCatalogo(ConexionPostgreSQL conexionPostgreSQL)
        {
            List<CatalogoDTO> catalogo = new List<CatalogoDTO>();

            // Declaramos una conexión del tipo de nuestro NuGet de PostgreSQL, la inicializamos y construímos la conexión con los parámetros de nuestra BBDD previamente definidos en otra clase, pero traídos como constantes aquí (por razones de seguridad y abstracción)
            NpgsqlConnection conexionGenerada = new NpgsqlConnection();
            conexionGenerada = conexionPostgreSQL.GeneraConexion(VariablesConexionPostgreSQL.HOST, VariablesConexionPostgreSQL.PORT, VariablesConexionPostgreSQL.DB, VariablesConexionPostgreSQL.USER, VariablesConexionPostgreSQL.PASS);

            // Declaramos una variable para mostrar el flujo del programa por la consola y para debugear mejor en un futuro
            var estadoGenerada = string.Empty;
            estadoGenerada = conexionGenerada.State.ToString();
            System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Estado conexión generada: " + estadoGenerada + "\n");

            try
            {
                // Definimos la consulta y la ejecutamos
                NpgsqlCommand consulta = new NpgsqlCommand("SELECT * FROM \"dlk_operacional_productos\".\"opr_cat_productos\"", conexionGenerada);
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();

                // Guardamos en una lista los datos obtenidos de la consulta select
                catalogo = PostgreSQLToDTOs.ConsultaSelectCatalogoToDTO(resultadoConsulta);

                // Cerramos el flujo de los datos resultantes de la consulta
                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Cierre del conjunto de datos\n");
                resultadoConsulta.Close();

                // Cerramos la conexión a nuestra BBDD
                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Cierre de la conexión\n");
                conexionGenerada.Close();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Error al ejecutar consulta: " + e + "\n");
            }

            return catalogo;
        }

        /****************************************** CONSULTAS INSERT *******************************************/

        public static void ConsultaInsertCatalogo(ConexionPostgreSQL conexionPostgreSQL)
        {
            NpgsqlConnection conexionGenerada = new NpgsqlConnection();
            conexionGenerada = conexionPostgreSQL.GeneraConexion(VariablesConexionPostgreSQL.HOST, VariablesConexionPostgreSQL.PORT, VariablesConexionPostgreSQL.DB, VariablesConexionPostgreSQL.USER, VariablesConexionPostgreSQL.PASS);

            var estadoGenerada = string.Empty;
            estadoGenerada = conexionGenerada.State.ToString();
            System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Estado conexión generada: " + estadoGenerada + "\n");

            try
            {
                NpgsqlCommand consulta = new NpgsqlCommand("INSERT INTO \"dlk_operacional_productos\".\"opr_cat_productos\" (md_uuid, md_fch, id_producto, cod_producto, nombre_producto, tipo_producto_origen, tipo_producto_clase, des_producto, fch_alta_producto, fch_baja_producto) VALUES ('111AAA', '2022-10-13', DEFAULT, 'a1', 'RedBull', 'denominacion EEUU', 'denominacion ESP', 'bebida energetica', TIMESTAMP '2022-10-12 13:00:00', TIMESTAMP '2022-10-13 14:00:00')", conexionGenerada);
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();

                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Cierre del conjunto de datos\n");
                resultadoConsulta.Close();

                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Cierre de la conexión\n");
                conexionGenerada.Close();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("\n\n\t[INFORMACIÓN-ConsultasPostgreSQL.cs] Error al ejecutar consulta: " + e + "\n");
            }
        }
    }
}

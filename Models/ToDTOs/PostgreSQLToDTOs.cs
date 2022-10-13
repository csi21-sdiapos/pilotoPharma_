using Npgsql;
using PilotoPharma.Models.DTOs;

namespace PilotoPharma.Models.ToDTOs
{
    public class PostgreSQLToDTOs
    {
        public static List<CatalogoDTO> ConsultaSelectCatalogoToDTO(NpgsqlDataReader resultadoConsulta)
        {
            List<CatalogoDTO> catalogo = new List<CatalogoDTO>();

            while (resultadoConsulta.Read())
            {
                catalogo.Add
                    (
                        new CatalogoDTO
                            (
                                Convert.ToString(resultadoConsulta[0]),
                                Convert.ToDateTime(resultadoConsulta[1]),
                                Convert.ToInt32(resultadoConsulta[2]),
                                Convert.ToString(resultadoConsulta[3]),
                                Convert.ToString(resultadoConsulta[4]),
                                Convert.ToString(resultadoConsulta[5]),
                                Convert.ToString(resultadoConsulta[6]),
                                Convert.ToString(resultadoConsulta[7]),
                                Convert.ToDateTime(resultadoConsulta[8]),
                                Convert.ToDateTime(resultadoConsulta[9])
                            )
                    );
            }

            return catalogo;
        }
    }
}

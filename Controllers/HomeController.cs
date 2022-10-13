using Microsoft.AspNetCore.Mvc;
using PilotoPharma.Models;
using PilotoPharma.Models.Conexiones;
using PilotoPharma.Models.Consultas;
using PilotoPharma.Models.DTOs;
using System.Diagnostics;

namespace PilotoPharma.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            System.Console.WriteLine("\n\n\t[INFORMACIÓN-HomeController-Index] Entra en Index\n");

            /************ Declaramos un objeto de nuestra clase ConexionPostgreSQL y lo inicializamos () ************/
            // para esto usamos su constructor vacío (que cuando una clase no tiene constructor definido, predetermiandamente lleva el constructor vacío)
            ConexionPostgreSQL conexionPostgreSQL = new ConexionPostgreSQL(); // este objeto se lo iremos pasando como parámetro en las llamadas a nuestras consultas

            /***************** Obtenemos los catálogos de la BBDD y los mostramos por consola ***************/

            List<CatalogoDTO> catalogo = new List<CatalogoDTO>();
            catalogo = ConsultasPostgreSQL.ConsultaSelectCatalogo(conexionPostgreSQL);

            System.Console.WriteLine("\n\n\tMd uuId\tMd Fecha\tID Producto\tCod Producto\tNom. Producto\tTipo Origen\t Tipo Clase\tDes. Producto\tFecha Alta\tFecha Baja");
            System.Console.WriteLine("\t-----------------------------------------------------------------------------------------");

            foreach (CatalogoDTO c in catalogo)
                System.Console.WriteLine(c.ToString());

            /*************************** Hacemos un insert de un catálogo ************************/

            ConsultasPostgreSQL.ConsultaInsertCatalogo(conexionPostgreSQL);

            /***************** Obtenemos los catalogos de la BBDD y los mostramos por consola ***************/

            catalogo = new List<CatalogoDTO>();
            catalogo = ConsultasPostgreSQL.ConsultaSelectCatalogo(conexionPostgreSQL);

            System.Console.WriteLine("\n\n\tMd uuId\tMd Fecha\tID Producto\tCod Producto\tNom. Producto\tTipo Origen\t Tipo Clase\tDes. Producto\tFecha Alta\tFecha Baja");
            System.Console.WriteLine("\t-----------------------------------------------------------------------------------------");

            foreach (CatalogoDTO c in catalogo)
                System.Console.WriteLine(c.ToString());


            /**** finalmente devolvemos la vista, al igual que cualquier otro método del tipo IActionResult ***/
            System.Console.WriteLine("\n\n\t[INFORMACIÓN-HomeController-Index] Lógica del Index finalizada\n");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
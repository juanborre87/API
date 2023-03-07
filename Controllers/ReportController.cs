using ApiFrabricaDeAutos.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiFrabricaDeAutos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        public static List<Car> carList = new List<Car>();
        public static List<DistributionCenter> distributionCenterList = new List<DistributionCenter>();

        /// <summary>
        /// Genera un reporte de ventas
        /// </summary>
        /// <returns></returns>
        [HttpGet("sales")]
        public Report SalesReport()
        {
            Report report = new Report();
            try
            {
                //reporte = CalcularReporte();
                return report;

            }
            catch (Exception ex)
            {
                return new Report
                {
                    message = "Ha ocurrido un error al cargar el reporte" + ex.Message
                };
            }
        }
    }
}

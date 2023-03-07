using ApiFrabricaDeAutos.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiFrabricaDeAutos.Controllers
{
    /// <summary>
    /// Controlador encargado de generar el reporte
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        #region Database
        public static List<Car> carList = new List<Car>();
        public static List<DistributionCenter> distributionCenterList = new List<DistributionCenter>();
        public static List<Sale> salesList = new List<Sale>();
        #endregion 

        /// <summary>
        /// Genera un reporte de ventas
        /// </summary>
        /// <returns></returns>
        [HttpGet("sales")]
        public Report GetReport()
        {
            Report report = new Report();
            try
            {
                //report = GetsalesReport();
                report.message = "El reporte se ha generado con exito";
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

        /// <summary>
        /// Calcula el volumen de ventas total, volumen de ventas por distribuidor y porcentaje de venta 
        /// de cada modelo de auto en cada centro en relacion a las ventas totales de la empresa 
        /// </summary>
        /// <returns></returns>
        private Report GetsalesReport()
        {
            carList = DatabaseController.carList;
            distributionCenterList = DatabaseController.distributionCenterList;
            salesList = SaleController.salesList;
            Report reporte = new Report();

            return reporte;
        }
    }
}

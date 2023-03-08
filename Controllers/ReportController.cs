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
        public static TotalSale totalSale = new TotalSale();
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
                report = GetsalesReport();
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
            carList = DatabaseController.carsDataBase;
            distributionCenterList = DatabaseController.distributionCentersDataBase;
            totalSale = DatabaseController.totalSaleDataBase;
            Report report = new Report();
            report.totalSale = totalSale.total;
            report.totalSalesByDistributionCenter = new List<Data1>();
            report.percentage = new List<Percentage>();
            foreach (var dtCenter in distributionCenterList)
            {
                report.totalSalesByDistributionCenter.Add(new Data1 // generando total de ventas por centro de distribucion
                {
                    name = dtCenter.distributionCenterData.Name, 
                    total = dtCenter.total                  
                });

                foreach (var autoSold in dtCenter.carsSoldList)
                {
                    report.percentage.Add(new Percentage // generando porcentajes de venta por cada modelo y por cada centro de distribucion
                    {
                        distributionCenter = new DistributionCenterData
                        {
                            Name = dtCenter.distributionCenterData.Name,
                        },
                        data = new List<Data2>
                        {
                            new Data2()
                            {
                                model = autoSold.car.model,
                                percent = autoSold.percentage
                            }
                        }
                    });

                }

            }
            
            return report;
        }
    }
}

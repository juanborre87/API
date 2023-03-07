using ApiFrabricaDeAutos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ApiFrabricaDeAutos.Controllers
{
    /// <summary>
    /// Controlador encargado de la persistencia de las ventas
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class SaleController : ControllerBase
    {
        #region Database
        public static List<Car> carList = new List<Car>();
        public static List<DistributionCenter> distributionCenterList = new List<DistributionCenter>();
        public static List<Sale> salesList = new List<Sale>();
        #endregion  

        /// <summary>
        /// Genera la venta y la almacena
        /// </summary>
        /// <param name="sale"></param>
        /// <returns></returns>
        [HttpPost("car")]
        public Sale CreateSale([FromBody] Sale sale)
        {
            carList = DatabaseController.carList;
            distributionCenterList = DatabaseController.distributionCenterList;
            try
            {
                // convirtiendo todo a minusculas y sin espacios
                sale.car.model = sale.car.model.ToLower().Trim(); 
                sale.distributionCenter.Name = sale.distributionCenter.Name.ToLower().Trim();

                if (distributionCenterList.FindAll(x => x.Name == sale.distributionCenter.Name).Count > 0) // validacion del nombre del centro de distribuiciòn 
                {
                    if (!string.IsNullOrEmpty(sale.car.model) && carList.FindAll(x => x.model == sale.car.model).Count > 0) // validacion del modelo del auto
                    {
                        salesList.Add(sale);
                        sale.message = "Venta aprobada";
                    }
                    else
                        sale.message = "No existe el modelo del auto";
                }
                else
                    sale.message = "No existe el centro de distribucion";

                return sale;

            }
            catch (Exception ex)
            {
                sale.message = "Ha ocurrido un error al cargar la venta" + ex.Message;
                return sale;
            }
        }


    }
}

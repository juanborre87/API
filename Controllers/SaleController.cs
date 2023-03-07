using ApiFrabricaDeAutos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ApiFrabricaDeAutos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleController : ControllerBase
    {
        public static List<Car> carList = new List<Car>();
        public static List<DistributionCenter> distributionCenterList = new List<DistributionCenter>();
        /// <summary>
        /// Metodo que genera la venta
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
                sale.car.model = sale.car.model.ToLower().Trim();
                sale.distributionCenter.Name = sale.distributionCenter.Name.ToLower().Trim();
                if (distributionCenterList.FindAll(x => x.Name == sale.distributionCenter.Name).Count > 0)
                {
                    if (!string.IsNullOrEmpty(sale.car.model) && carList.FindAll(x => x.model == sale.car.model).Count > 0)
                    {
                        sale.message = "Venta aprobada";
                        //ventasList.Add(sale);
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

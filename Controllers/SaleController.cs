using ApiFrabricaDeAutos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
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
        public static TotalSale totalSale = new TotalSale();
        #endregion  

        /// <summary>
        /// Genera la venta y la almacena
        /// </summary>
        /// <param name="newSale"></param>
        /// <returns></returns>
        [HttpPost("car")]
        public Sale CreateSale([FromBody] Sale newSale)
        {
            carList = DatabaseController.carsDataBase;
            distributionCenterList = DatabaseController.distributionCentersDataBase;
            totalSale = DatabaseController.totalSaleDataBase;
            try
            {
                // convirtiendo todo a minusculas y sin espacios
                newSale.car.model = newSale.car.model.ToLower().Trim(); 
                newSale.distributionCenter.Name = newSale.distributionCenter.Name.ToLower().Trim();

                if (distributionCenterList.FindAll(x => x.distributionCenterData.Name == newSale.distributionCenter.Name).Count > 0) // validacion del nombre del centro de distribuiciòn en BD
                {
                    if (!string.IsNullOrEmpty(newSale.car.model) && carList.FindAll(x => x.model == newSale.car.model).Count > 0) // validacion del modelo del auto en BD
                    {
                        double price = carList[carList.FindIndex(x => x.model == newSale.car.model)].price; // buscando precio real del auto vendido en BD
                        totalSale.total += price; // sumatoria de autos vendidos en BD - suma general
                        CarSold car = totalSale.carsSoldList[totalSale.carsSoldList.FindIndex(x => x.car.model == newSale.car.model)]; // buscando modelo de auto vendido en BD - listado general
                        car.amount++; // sumando cantidad autos vendidos por modelo en BD - conteo general

                        DistributionCenter distributionCenter = distributionCenterList[distributionCenterList.FindIndex(x => x.distributionCenterData.Name == newSale.distributionCenter.Name)]; // buscando distribuidor que realizò la venta en BD                  
                        distributionCenter.total += price; // sumatoria del precio los autos vendidos por distribuidor y almacenamiento en BD
                        CarSold carSold = distributionCenter.carsSoldList[distributionCenter.carsSoldList.FindIndex(x => x.car.model == newSale.car.model)]; // buscando modelo del auto vendido
                        carSold.amount++; // sumando cantidad de autos vendidos por modelo ya que estamos ubicados en el distribuidor que realizò la venta, almacenamiento en la base de datos

                        foreach (var dtCenter in distributionCenterList) // calculando y guardando porcentaje de venta por modelo y por distribuidor
                        {
                            foreach (var autoSold in dtCenter.carsSoldList)
                            {
                                if (autoSold.car.model == newSale.car.model)
                                {
                                    if (autoSold.amount > 0)
                                        autoSold.percentage = (autoSold.amount * 100) / car.amount;
                                }

                            }
                        }

                        newSale.message = "Venta aprobada";
                    }
                    else
                        newSale.message = "No existe el modelo del auto";
                }
                else
                    newSale.message = "No existe el centro de distribucion";

                return newSale;

            }
            catch (Exception ex)
            {
                newSale.message = "Ha ocurrido un error al cargar la venta" + ex.Message;
                return newSale;
            }
        }


    }
}

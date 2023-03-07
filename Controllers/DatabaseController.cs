using ApiFrabricaDeAutos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;

namespace ApiFrabricaDeAutos.Controllers
{
    /// <summary>
    /// Controlador encargado de llenar las listas para utilizarlas como supuesta base de datos
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class DatabaseController : ControllerBase
    {
        #region Database
        public static List<Car> carList = new List<Car>();
        public static List<DistributionCenter> distributionCenterList = new List<DistributionCenter>();
        #endregion

        // <summary>
        /// Inserta los datos iniciales  de los autos
        /// </summary>
        /// <param name="venta"></param>
        /// <returns></returns>
        [HttpPost("car")]
        public string CarDataBase([FromBody] List<Car> cars)
        {
            try
            {
                carList = cars.ToList();              
                foreach (var car in carList)
                {
                    car.model = car.model.ToLower().Trim(); // convirtiendo todo a minusculas y sin espacios
                    if (car.model == "sport")
                        car.price = car.price + (car.price * 0.7); // calculando el impuesto  del 70% al auto modelo sport
                }
                return "Los datos se han cargado correctamente";
            }
            catch (Exception ex)
            {
                return "Ha ocurrido un error al cargar los datos" + ex.Message;
            }
        }

        // <summary>
        /// Inserta los datos iniciales de los centros de distribucion
        /// </summary>
        /// <param name="venta"></param>
        /// <returns></returns>
        [HttpPost("distributioncenter")]
        public string DistributionCenterDataBase([FromBody] List<DistributionCenter> distributionCenters)
        {
            try
            {
                distributionCenterList = distributionCenters.ToList();
                foreach (var distributionCenter in distributionCenterList)
                {
                    distributionCenter.Name = distributionCenter.Name.ToLower().Trim(); // convirtiendo todo a minusculas y sin espacios
                }
                return "Los datos se han cargado correctamente";
            }
            catch (Exception ex)
            {
                return "Ha ocurrido un error al cargar los datos" + ex.Message;
            }
        }

    }
}

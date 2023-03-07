﻿using ApiFrabricaDeAutos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;

namespace ApiFrabricaDeAutos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DatabaseController : ControllerBase
    {
        //Datos filtrados provenientes de una supuesta base de datos real - BD interna
        public static List<Car> carList = new List<Car>();
        public static List<DistributionCenter> distributionCenterList = new List<DistributionCenter>();

        // <summary>
        /// Metodo que inserta los datos iniciales  de los autos a la BD interna
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
                    car.model = car.model.ToLower().Trim();
                    if (car.model == "sport")
                        car.price = car.price + (car.price * 0.7);
                }
                return "Los datos se han cargado correctamente";
            }
            catch (Exception ex)
            {
                return "Ha ocurrido un error al cargar los datos" + ex.Message;
            }
        }

        // <summary>
        /// Metodo que inserta los datos iniciales de los distribuidoresa la BD interna
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
                    distributionCenter.Name = distributionCenter.Name.ToLower().Trim();
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
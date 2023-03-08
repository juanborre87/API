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
        public static List<Car> carsDataBase = new List<Car>();
        public static List<DistributionCenter> distributionCentersDataBase = new List<DistributionCenter>();
        public static TotalSale totalSaleDataBase = new TotalSale();
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
                if (carsDataBase.Count == 0)
                {
                    carsDataBase = cars.ToList(); // almacenamiento del listado de autos en la base de datos interna
                    foreach (var car in carsDataBase)
                    {
                        car.model = car.model.ToLower().Trim(); // convirtiendo todo a minusculas y sin espacios
                        if (car.model == "sport")
                            car.price = car.price + (car.price * 0.7); // calculando el impuesto  del 70% al auto modelo sport
                    }
                    foreach (var distributionCenter in distributionCentersDataBase) // almacenamiento del listado de autos por cada distribuidor en la base de datos interna
                    {
                        distributionCenter.carsSoldList = new List<CarSold>();
                        foreach (var car in carsDataBase)
                        {
                            distributionCenter.carsSoldList.Add(new CarSold
                            {
                                car = new Car
                                {
                                    model = car.model,
                                    id = car.id,
                                    price = car.price,
                                    message = ""
                                }
                            });
                        }

                    }
                    totalSaleDataBase.carsSoldList = new List<CarSold>();
                    foreach (var car in carsDataBase) // almacenamiento del listado de autos en la base de datos interna - listado general
                    {
                        totalSaleDataBase.carsSoldList.Add(new CarSold
                        {
                            car = new Car
                            {
                                model = car.model,
                                id = car.id,
                                price = car.price,
                                message = ""
                            }
                        });
                    }
                }
                else
                {
                    foreach (var car in cars)
                    {
                        car.model = car.model.ToLower().Trim(); // convirtiendo todo a minusculas y sin espacios
                        if (carsDataBase.FindAll(x => x.model == car.model).Count == 0)
                        {
                            if (car.model == "sport")
                                car.price = car.price + (car.price * 0.7); // calculando el impuesto  del 70% al auto modelo sport
                            carsDataBase.Add(car); // adiciona un nuevo modelo a la lista de autos

                            foreach (var distributionCenter in distributionCentersDataBase) // adiciona un nuevo modelo a todos los distribuidores
                            {
                                distributionCenter.carsSoldList.Add(new CarSold
                                {
                                    car = new Car
                                    {
                                        model = car.model,
                                        id = car.id,
                                        price = car.price,
                                        message = ""
                                    }
                                });
                            }
                            totalSaleDataBase.carsSoldList.Add(new CarSold // adiciona un nuevo modelo a la lista general
                            {
                                car = new Car
                                {
                                    model = car.model,
                                    id = car.id,
                                    price = car.price,
                                    message = ""
                                }
                            });
                        }

                    }
                }                 
                return "Los datos se han cargado correctamente";
            }
            catch (Exception ex)
            {
                return "Ha ocurrido un error al cargar los datos /" + ex.Message;
            }
        }

        // <summary>
        /// Inserta los datos iniciales de los centros de distribucion
        /// </summary>
        /// <param name="venta"></param>
        /// <returns></returns>
        [HttpPost("distributioncenter")]
        public string DistributionCenterDataBase([FromBody] List<DistributionCenterData> distributionCenters)
        {
            try
            {
                if (distributionCentersDataBase.Count == 0)
                {
                    foreach (var distributionCenter in distributionCenters)
                    {
                        distributionCenter.Name = distributionCenter.Name.ToLower().Trim(); // convirtiendo todo a minusculas y sin espacios
                        distributionCentersDataBase.Add(new DistributionCenter
                        {
                            distributionCenterData = new DistributionCenterData
                            {
                                id = distributionCenter.id,
                                Name = distributionCenter.Name,
                                message = ""
                            }
                        });
                    }
                }
                else 
                {
                    foreach (var distributionCenter in distributionCenters)
                    {
                        distributionCenter.Name = distributionCenter.Name.ToLower().Trim(); // convirtiendo todo a minusculas y sin espacios
                        if (distributionCentersDataBase.FindAll(x => x.distributionCenterData.Name == distributionCenter.Name).Count == 0)
                        {
                            distributionCentersDataBase.Add(new DistributionCenter
                            {
                                distributionCenterData = new DistributionCenterData
                                {
                                    id = distributionCenter.id,
                                    Name = distributionCenter.Name,
                                    message = ""
                                }
                            });
                        }

                    }
                }
                return "Los datos se han cargado correctamente";
            }
            catch (Exception ex)
            {
                return "Ha ocurrido un error al cargar los datos /" + ex.Message;
            }
        }

    }
}

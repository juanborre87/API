namespace ApiFrabricaDeAutos.Models
{
    /// <summary>
    /// Centro de distribucion
    /// </summary>
    public class DistributionCenter
    {
        /// <summary>
        /// Datos basicos del centro de distribucion
        /// </summary>
        public DistributionCenterData distributionCenterData { get; set; }
        /// <summary>
        /// Total en $ de todos los autos vendidos 
        /// </summary>
        public double total { get; set; }
        /// <summary>
        /// Listado de autos vendidos
        /// </summary>
        public List<CarSold> carsSoldList { get; set; }

    }
}

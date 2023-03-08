namespace ApiFrabricaDeAutos.Models
{
    /// <summary>
    /// Datos basicos del centro de distribucion
    /// </summary>
    public class DistributionCenterData
    {
        /// <summary>
        /// Id unico de cada centro de distribucion
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Nombre del centro de distribucion
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Mensaje
        /// </summary>
        public string message { get; set; }
    }
}

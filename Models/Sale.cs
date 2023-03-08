namespace ApiFrabricaDeAutos.Models
{
    /// <summary>
    /// Venta
    /// </summary>
    public class Sale
    {
        /// <summary>
        /// Auto
        /// </summary>
        public Car car { get; set; }
        /// <summary>
        /// Centro de distribucion
        /// </summary>
        public DistributionCenterData distributionCenter { get; set; }
        /// <summary>
        /// Mensaje
        /// </summary>
        public string message { get; set; }
    }
}

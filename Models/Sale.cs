namespace ApiFrabricaDeAutos.Models
{
    /// <summary>
    /// Venta
    /// </summary>
    public class Sale
    {
        public Car car { get; set; }
        public DistributionCenterData distributionCenter { get; set; }
        public string message { get; set; }
    }
}

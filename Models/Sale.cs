namespace ApiFrabricaDeAutos.Models
{
    /// <summary>
    /// Atributos de una venta
    /// </summary>
    public class Sale
    {
        public Car car { get; set; }
        public DistributionCenter distributionCenter { get; set; }
        public string message { get; set; }
    }
}

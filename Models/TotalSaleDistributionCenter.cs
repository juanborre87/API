namespace ApiFrabricaDeAutos.Models
{
    /// <summary>
    /// Volumen de ventas por centro de distribucion
    /// </summary>
    public class TotalSaleDistributionCenter
    {
        /// <summary>
        /// Total en dinero de todos los autos vendidos 
        /// </summary>
        public double totalSale { get; set; }
        /// <summary>
        /// Centro de distribuciòn
        /// </summary>
        public DistributionCenter distributionCenter { get; set; }
        /// <summary>
        /// Listado de cantidad de autos vendidos y porcentajes de venta por modelo
        /// </summary>
        public List<TotalCarsSold> totalCarsSold { get; set; }
    }
}

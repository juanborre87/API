namespace ApiFrabricaDeAutos.Models
{
    /// <summary>
    /// Reporte general
    /// </summary>
    public class Report
    {
        /// <summary>
        /// Volumen de ventas de toda la fabrica
        /// </summary>
        public TotalFactorySales factory { get; set; }
        /// <summary>
        /// Listado de volumen de ventas por centro de distribuciòn
        /// </summary>
        public List<TotalSaleDistributionCenter> distributionCenter { get; set; }
        /// <summary>
        /// mensaje
        /// </summary>
        public string message { get; set; }
    }
}

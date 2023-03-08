namespace ApiFrabricaDeAutos.Models
{
    /// <summary>
    /// Reporte general
    /// </summary>
    public class Report
    {
        /// <summary>
        /// Total de ventas
        /// </summary>
        public double totalSale { get; set; }
        /// <summary>
        /// Listado de totales de las ventas de cada centro de distribucion
        /// </summary>
        public List<Data1> totalSalesByDistributionCenter { get; set; }
        /// <summary>
        /// Listado de porcentajes de las ventas de cada centro de distribucion por cada modelo de auto
        /// </summary>
        public List<Percentage> percentage { get; set; }
        /// <summary>
        /// Mensaje
        /// </summary>
        public string message { get; set; }
    }
}

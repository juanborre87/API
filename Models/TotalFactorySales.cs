namespace ApiFrabricaDeAutos.Models
{
    /// <summary>
    /// Volumen de ventas de toda la fabrica de autos
    /// </summary>
    public class TotalFactorySales
    {
        /// <summary>
        /// Total en dinero de todos los autos vendidos  
        /// </summary>
        public double totalSale { get; set; }
        /// <summary>
        /// Listado de la cantidad de autos vendidos por cada modelo
        /// </summary>
        public List<TotalCarsSold> totalCarsSold { get; set; }
    }
}

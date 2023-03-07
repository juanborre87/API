namespace ApiFrabricaDeAutos.Models
{
    /// <summary>
    /// Autos vendidos
    /// </summary>
    public class TotalCarsSold
    {
        /// <summary>
        /// Entidad auto
        /// </summary>
        public Car car { get; set; }
        /// <summary>
        /// Cantidad de autos vendidos
        /// </summary>
        public int amount { get; set; }
        /// <summary>
        /// Pocentajes de venta 
        /// </summary>
        public double percentageSales { get; set; }
    }
}

namespace ApiFrabricaDeAutos.Models
{
    /// <summary>
    /// Ventas generales
    /// </summary>
    public class TotalSale
    {
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

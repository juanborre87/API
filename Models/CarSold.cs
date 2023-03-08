namespace ApiFrabricaDeAutos.Models
{
    /// <summary>
    /// Auto vendido
    /// </summary>
    public class CarSold
    {
        /// <summary>
        /// Auto vendido
        /// </summary>
        public Car car { get; set; }
        /// <summary>
        /// Cantidad de autos vendidos
        /// </summary>
        public int amount { get; set; }
        /// <summary>
        /// Percentage de ventas
        /// </summary>
        public double percentage { get; set; }
    }
}

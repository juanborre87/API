namespace ApiFrabricaDeAutos.Models
{
    /// <summary>
    /// Automovil
    /// </summary>
    public class Car
    {
        /// <summary>
        /// Id del auto
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Modelo del auto
        /// </summary>
        public string model { get; set; }
        /// <summary>
        /// Precio del auto
        /// </summary>
        public double price { get; set; }
        /// <summary>
        /// Mensaje
        /// </summary>
        public string message { get; set; }
    }
}

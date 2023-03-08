namespace ApiFrabricaDeAutos.Models
{
    public class Percentage
    {
        /// <summary>
        /// Distribuidor - Datos basicos
        /// </summary>
        public DistributionCenterData distributionCenter { get; set; }
        /// <summary>
        /// Listado para calcular el porcentaje
        /// </summary>
        public List<Data2> data { get; set; }
    }
}

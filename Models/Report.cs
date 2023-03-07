namespace ApiFrabricaDeAutos.Models
{
    public class Report
    {
        public List<TotalSaleFactory> factory { get; set; }
        public List<TotalSaleDtCenter> distributionCenter { get; set; }
        public string message { get; set; }
    }
}

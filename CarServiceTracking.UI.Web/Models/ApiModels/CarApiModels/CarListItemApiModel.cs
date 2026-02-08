namespace CarServiceTracking.UI.Web.Models.ApiModels.CarApiModels
{
    public class CarListItemApiModel
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; } = string.Empty;
        public string BrandModel { get; set; } = string.Empty;
    }
}

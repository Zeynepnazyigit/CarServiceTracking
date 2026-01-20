namespace CarServiceTracking.Core.DTOs.CarDTOs
{
    public class CarListItemDTO
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; } = string.Empty;
        public string BrandModel { get; set; } = string.Empty;
    }
}

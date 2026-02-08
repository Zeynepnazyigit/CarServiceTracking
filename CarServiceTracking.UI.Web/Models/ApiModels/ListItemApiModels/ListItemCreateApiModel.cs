namespace CarServiceTracking.UI.Web.Models.ApiModels.ListItemApiModels
{
    public class ListItemCreateApiModel
    {
        public string Name { get; set; } = string.Empty;
        public string ListType { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int? ParentId { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

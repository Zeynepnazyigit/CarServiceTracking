namespace CarServiceTracking.UI.Web.ViewModels.ListItems
{
    public class ListItemListVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ListType { get; set; } = string.Empty;
        public int? ParentId { get; set; }
        public string? ParentName { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
    }
}

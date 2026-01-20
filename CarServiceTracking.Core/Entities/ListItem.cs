using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceTracking.Core.Entities
{
    public class ListItem : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string ListType { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int? ParentId { get; set; }
        public int SortOrder { get; set; }

        public virtual ListItem? Parent { get; set; }
        public virtual ICollection<ListItem> Children { get; set; } = new List<ListItem>();
    }
}

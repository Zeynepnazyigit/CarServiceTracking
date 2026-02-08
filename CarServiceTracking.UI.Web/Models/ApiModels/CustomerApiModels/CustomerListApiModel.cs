using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceTracking.UI.Web.Models.ApiModels.CustomerApiModels
{
    public class CustomerListApiModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? City { get; set; }
        public string? CompanyName { get; set; }
        public int? CustomerTypeId { get; set; }
        public string? CustomerTypeName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int TotalVehicles { get; set; }
        public int TotalServices { get; set; }
    }
}

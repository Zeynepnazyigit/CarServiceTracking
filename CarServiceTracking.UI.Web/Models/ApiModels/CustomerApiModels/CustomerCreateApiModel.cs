using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceTracking.UI.Web.Models.ApiModels.CustomerApiModels
{
    public class CustomerCreateApiModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
        public string? TaxNumber { get; set; }
        public string? CompanyName { get; set; }
        public string? Notes { get; set; }
        public int? CustomerTypeId { get; set; }
    }
}

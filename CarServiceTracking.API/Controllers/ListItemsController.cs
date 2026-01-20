using CarServiceTracking.Data.Contexts;
using CarServiceTracking.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListItemsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ListItemsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("seed")]
        public async Task<IActionResult> Seed()
        {
            if (_context.Set<ListItem>().Any())
                return Ok("ListItem zaten dolu.");

            var items = new List<ListItem>
            {
                // Fuel Types
                new ListItem { Name="Benzin", ListType="FuelType", SortOrder=1, IsActive=true, IsDeleted=false },
                new ListItem { Name="Dizel", ListType="FuelType", SortOrder=2, IsActive=true, IsDeleted=false },
                new ListItem { Name="Elektrik", ListType="FuelType", SortOrder=3, IsActive=true, IsDeleted=false },
                new ListItem { Name="Hybrid", ListType="FuelType", SortOrder=4, IsActive=true, IsDeleted=false },

                // Transmission Types
                new ListItem { Name="Manuel", ListType="TransmissionType", SortOrder=1, IsActive=true, IsDeleted=false },
                new ListItem { Name="Otomatik", ListType="TransmissionType", SortOrder=2, IsActive=true, IsDeleted=false },

                // Car Types
                new ListItem { Name="Sedan", ListType="CarType", SortOrder=1, IsActive=true, IsDeleted=false },
                new ListItem { Name="Hatchback", ListType="CarType", SortOrder=2, IsActive=true, IsDeleted=false },
                new ListItem { Name="SUV", ListType="CarType", SortOrder=3, IsActive=true, IsDeleted=false },
                new ListItem { Name="Pickup", ListType="CarType", SortOrder=4, IsActive=true, IsDeleted=false },
            };

            await _context.Set<ListItem>().AddRangeAsync(items);
            await _context.SaveChangesAsync();

            return Ok("ListItem seed tamamlandı ✅");
        }
    }
}

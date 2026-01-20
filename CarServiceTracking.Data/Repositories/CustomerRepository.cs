using CarServiceTracking.Core.Entities;
using CarServiceTracking.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceTracking.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Customer?> GetByEmailAsync(string email)
        {
            return await _context.Customers
                .FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<bool> IsEmailExistsAsync(string email, int? excludeId = null)
        {
            if (excludeId.HasValue)
            {
                return await _context.Customers
                    .AnyAsync(c => c.Email == email && c.Id != excludeId.Value);
            }

            return await _context.Customers
                .AnyAsync(c => c.Email == email);
        }

        public async Task<IEnumerable<Customer>> GetActiveCustomersAsync()
        {
            return await _context.Customers
                .Where(c => c.IsActive)
                .OrderBy(c => c.FirstName)
                .ThenBy(c => c.LastName)
                .ToListAsync();
        }

        public async Task<IEnumerable<Customer>> GetCustomersWithVehiclesAsync()
        {
            // Vehicle entity'si henüz yok, şimdilik basit sorgu
            return await _context.Customers
                .Where(c => c.IsActive)
                .OrderBy(c => c.FirstName)
                .ToListAsync();
        }

        public async Task<Customer?> GetCustomerWithDetailsAsync(int customerId)
        {
            // İlişkili tablolar henüz yok, şimdilik basit sorgu
            return await _context.Customers
                .FirstOrDefaultAsync(c => c.Id == customerId);
        }
    }
}
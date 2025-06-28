using ContactMangementServices.Modal;
using ContactMangementServices.Services;
using Microsoft.EntityFrameworkCore;
using System;

namespace ContactMangementServices.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly ContactMangementDbContext _context;

        public CityRepository(ContactMangementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<City>> GetAllAsync() =>
            await _context.Cities.Include(c => c.State).ToListAsync();

        public async Task<City> GetByIdAsync(int id) =>
            await _context.Cities.Include(c => c.State).FirstOrDefaultAsync(c => c.CityId == id);

        public async Task AddAsync(City city)
        {
            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(City city)
        {
            _context.Cities.Update(city);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city != null)
            {
                _context.Cities.Remove(city);
                await _context.SaveChangesAsync();
            }
        }
    }

}

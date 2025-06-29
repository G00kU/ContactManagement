using ContactMangementServices.Modal;
using Microsoft.EntityFrameworkCore;

namespace ContactMangementServices.Services
{
    public class ContactMangementDbContext : DbContext
    {

        public ContactMangementDbContext(DbContextOptions options):base(options) { 
        
        
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}

using ContactMangementServices.Modal;
using ContactMangementServices.Services;
using Microsoft.EntityFrameworkCore;

namespace ContactMangementServices.Repository
{
    public class ContactRepository: IContactRepository
    {
        //Task<IEnumerable<Contact>> GetAllAsync();
        //Task<IEnumerable<Contact>> GetContactsByName(string name);
        //Task<Contact> GetByIdAsync(int id);
        //Task AddAsync(Contact country);
        //Task UpdateAsync(Contact country);
        //Task DeleteAsync(int id);

        private readonly ContactMangementDbContext _context;
        private readonly ILogger _logger;

        public ContactRepository(ContactMangementDbContext context,ILogger<ContactRepository> logger)
        {
            _context = context;
            _logger= logger;
        }
        public async Task<IEnumerable<Contact>> GetAllAsync() {
            try
            {
                return await _context.Contacts.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex ,"Error Occured While Getting All Contacts"+ex.Message);
                throw;
            }
        
        }
        public async Task<IEnumerable<Contact>> GetContactsByName(string name)
        {
            try
            {
                return await _context.Contacts.Where(con => con.FirstName.Contains(name)).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured While Getting Getting Contacts Beased on Names" + ex.Message);
                throw;
            }
        
        }
        public async Task<Contact> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Contacts.FirstOrDefaultAsync(con => con.ContactId == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured While Getting Getting Contacts Beased on ID" + ex.Message);
                throw;
            }
        }
        public async Task<int> AddAsync(Contact con)
        {
            try
            {
                await _context.Contacts.AddAsync(con);
                await _context.SaveChangesAsync();
                return con.ContactId;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured While Adding" + ex.Message);
                throw;
            }
        }

        public async Task<int> UpdateAsync(Contact con)
        {
            try
            {
                _context.Contacts.Update(con);
                await _context.SaveChangesAsync();
                return con.ContactId;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured While Updating" + ex.Message);
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var selectedContact = await _context.Contacts.FirstOrDefaultAsync(con => con.ContactId == id);
                if (selectedContact != null)
                {
                    _context.Contacts.Remove(selectedContact);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                    _logger.LogWarning("Selected Contact is not Present ");
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured While Deleting" + ex.Message);
                throw;
            }
        }

    }
}

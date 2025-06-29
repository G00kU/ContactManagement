using ContactMangementServices.Modal;
public interface IContactRepository
{
    Task<IEnumerable<Contact>> GetAllAsync();
    Task<IEnumerable<Contact>> GetContactsByName(string name);
    Task<Contact> GetByIdAsync(int id);
    Task<int> AddAsync(Contact country);
    Task<int> UpdateAsync(Contact country);
    Task<bool> DeleteAsync(int id);
}
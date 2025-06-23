using ContactServices.Modal;
using ContactServices.Repository;
namespace ContactServices.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository _contactRepository;

    public ContactService(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public List<ContactDTO> GetAllContacts()
    {
        return _contactRepository.GetAllContact();
    }

    public ContactDTO GetContactById(int id) { 
        return _contactRepository.GetContactById(id);
    }    
    
    public int InsertorUpdateContact(ContactDTO contact)
    {
        return _contactRepository.InsertorUpdateContact(contact);
    }
    public int DeleteContact(int id) { 
        return _contactRepository.DeleteContact(id);    
    }

}



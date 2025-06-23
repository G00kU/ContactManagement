using ContactServices.Modal;
namespace ContactServices.Services;
public interface IContactService
{
    List<ContactDTO> GetAllContacts();  
    ContactDTO GetContactById(int contactId); 
    int InsertorUpdateContact(ContactDTO contact);
    int DeleteContact(int contactId);
}

using ContactServices.Modal;

namespace ContactServices.Repository
{
    public interface IContactRepository
    {
        List<ContactDTO> GetAllContact();
        ContactDTO GetContactById(int id);
        int InsertorUpdateContact(ContactDTO contact);
        int DeleteContact(int id);
    }
}




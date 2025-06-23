using Moq;
using ContactServices.Modal;
using ContactServices.Services;
using System.Collections.Generic;

public static class MockService
{
    public static Mock<IContactService> GetMockContactService()
    {
        var mockService = new Mock<IContactService>();
        mockService.Setup(service => service.GetAllContacts()).Returns(new List<ContactDTO>
        {
            new ContactDTO { ContactId = 1, FirstName = "John", LastName = "Doe", Email = "john@example.com" },
            new ContactDTO { ContactId = 2, FirstName = "Jane", LastName = "Smith", Email = "jane@example.com" }
        });
        mockService.Setup(service => service.GetContactById(It.IsAny<int>())).Returns<int>(id => new ContactDTO
        {
            ContactId = id,
            FirstName = "Mocked",
            LastName = "Contact",
            Email = $"{id}@mock.com"
        });

        return mockService;
    }
}

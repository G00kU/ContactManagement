using Moq;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using ContactServices.Controllers;
using ContactServices.Modal;
using ContactServices.Services;
using System.Collections.Generic;
namespace ContactServices.Test;
public class TestControllerTests
{
    private readonly TestController _testController;
    private readonly Mock<IContactService> _mockContactService;

    public TestControllerTests()
    {
        _mockContactService = MockService.GetMockContactService();
        _testController = new TestController(_mockContactService.Object);
    }

    [Fact]
    public void GetAllContacts_Returns_OkResult_With_Mocked_Contacts()
    {
        var result = _testController.GetAllContacts();
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<ContactDTO>>(okResult.Value);
        Assert.Equal(2, returnValue.Count);
        Assert.Equal("John", returnValue[0].FirstName);
        Assert.Equal("Jane", returnValue[1].FirstName);
    }

    [Fact]
    public void GetContactById_Returns_OkResult_With_Mocked_Contact()
    {
        var result = _testController.GetContactById(1);
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<ContactDTO>(okResult.Value);
        Assert.Equal(1, returnValue.ContactId);
        Assert.Equal("Mocked", returnValue.FirstName);
        Assert.Equal("Contact", returnValue.LastName);
        Assert.Equal("1@mock.com", returnValue.Email);
    }
}

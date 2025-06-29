using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using ContactMangementServices.Controllers;
using ContactMangementServices.Repository;
using ContactMangementServices.Modal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactManagementTest
{
    public class ContactControllerTests
    {
        private readonly Mock<IContactRepository> _mockRepo;
        private readonly ContactController _controller;

        public ContactControllerTests()
        {
            _mockRepo = new Mock<IContactRepository>();
            _controller = new ContactController(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOk_WithContacts()
        {
            var contacts = new List<Contact>
            {
                new Contact { ContactId = 1, FirstName = "John" },
                new Contact { ContactId = 2, FirstName = "Jane" }
            };

            _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(contacts);

            var result = await _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnContacts = Assert.IsType<List<Contact>>(okResult.Value);
            Assert.Equal(2, returnContacts.Count);
        }

        [Fact]
        public async Task GetById_ExistingId_ReturnsOk()
        {
            var contact = new Contact { ContactId = 1, FirstName = "John" };
            _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(contact);

            var result = await _controller.GetById(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnContact = Assert.IsType<Contact>(okResult.Value);
            Assert.Equal(1, returnContact.ContactId);
        }

        [Fact]
        public async Task GetById_InvalidId_ReturnsNotFound()
        {
            _mockRepo.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((Contact)null!);

            var result = await _controller.GetById(99);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Create_ReturnsCreatedAtAction()
        {
            var contact = new Contact { ContactId = 1, FirstName = "John" };

            _mockRepo.Setup(r => r.AddAsync(contact)).ReturnsAsync(contact.ContactId);

            var result = await _controller.Create(contact);

            var createdAt = Assert.IsType<CreatedAtActionResult>(result);
            var returnContact = Assert.IsType<Contact>(createdAt.Value);
            Assert.Equal("GetById", createdAt.ActionName);
        }

        [Fact]
        public async Task Update_ValidContact_ReturnsJsonResult()
        {
            var contact = new Contact { ContactId = 1, FirstName = "John Updated" };

            _mockRepo.Setup(r => r.UpdateAsync(contact)).ReturnsAsync(contact.ContactId);

            var result = await _controller.Update(contact);

            var json = Assert.IsType<JsonResult>(result);
            Assert.Equal(1, json.Value);
        }

        [Fact]
        public async Task Update_InvalidId_ReturnsBadRequest()
        {
            var contact = new Contact { ContactId = 0, FirstName = "Invalid" };

            var result = await _controller.Update(contact);

            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Contact ID mismatch", badRequest.Value);
        }

        [Fact]
        public async Task Delete_ReturnsJsonResult()
        {
            int contactId = 1;
            _mockRepo.Setup(r => r.DeleteAsync(contactId)).ReturnsAsync(true);

            var result = await _controller.Delete(contactId);

            var json = Assert.IsType<JsonResult>(result);
            Assert.Equal(true, json.Value);
        }
    }
}

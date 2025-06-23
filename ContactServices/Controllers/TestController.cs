using Microsoft.AspNetCore.Mvc;
using ContactServices.Modal;
using ContactServices.Services;
using System.Collections.Generic;

namespace ContactServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IContactService _contactService;

        public TestController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpGet("GetAllContacts")]
        public IActionResult GetAllContacts()
        {
            try
            {
                var contacts = _contactService.GetAllContacts();
                return Ok(contacts);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { success = false, message = "Error occurred: " + ex.Message });
            }
        }

        [HttpGet("GetContactById/{contactId}")]
        public IActionResult GetContactById(int contactId)
        {
            try
            {
                var contact = _contactService.GetContactById(contactId);
                return Ok(contact); 
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { success = false, message = "Error occurred: " + ex.Message });
            }
        }
    }
}

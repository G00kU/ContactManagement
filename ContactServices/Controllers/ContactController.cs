
using ContactServices.Modal;
using ContactServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace ContactServices.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpGet("GetAllContacts")]  
        public IActionResult GetAllContact()
        {
            try
            {
                List<ContactDTO> contacts = _contactService.GetAllContacts();
                return new JsonResult(contacts);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = "An error occurred while fetching contacts: " + ex.Message });
            }
        }


        [HttpGet("GetContactById/{ContactId}")]
        public IActionResult GetContactById(int ContactId)
        {
            try
            {
                var contact = _contactService.GetContactById(ContactId);
                return new JsonResult(contact);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = "An error occurred while fetching contact: " + ex.Message });
            }
        }

        [HttpPost("InsertorUpdateContact")]
        public IActionResult InsertorUpdateContact([FromBody] ContactDTO contact)
        {
            try
            {
                var result= _contactService.InsertorUpdateContact(contact);
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = "An error occurred while Updating contact: " + ex.Message });
            }
        }

        [HttpGet("DeleteContact/{contactId}")]
        public IActionResult DeleteContact(int contactId)
        {
            try
            {
                var result= _contactService.DeleteContact(contactId);
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = "An error occurred while Deleting contact: " + ex.Message });
            }
        }
    }
}

using ContactMangementServices.Modal;
using Microsoft.AspNetCore.Mvc;

namespace ContactMangementServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contacts = await _contactRepository.GetAllAsync();
            return Ok(contacts);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _contactRepository.GetByIdAsync(id);
            if (contact == null)
                return NotFound();

            return Ok(contact);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Contact contact)
        {
            await _contactRepository.AddAsync(contact);
            return CreatedAtAction(nameof(GetById), new { id = contact.ContactId }, contact);
        }



        [HttpPut]
        public async Task<IActionResult> Update(Contact contact)
        {
            if (contact.ContactId==0)
                return BadRequest("Contact ID mismatch");

            return new JsonResult(await _contactRepository.UpdateAsync(contact));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return new JsonResult(await _contactRepository.DeleteAsync(id));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using peace_kenya_api.Dtos.ContactUs;
using peace_kenya_api.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace peace_kenya_api.Controllers
{
    [Route("api/contact-us")]
    [ApiController]
    public class ContactUsController : BaseController
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create contact")]
        public async Task<IActionResult> Create([FromBody] CreateContactUsDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _contactUsService.CreateContactUs(dto);
            if (result.IsSuccess)
            {
                return CreatedAtAction(nameof(GetById), new { contactUsId = result.Data.ContactUsId }, result.Data);
            }
            return HandleResult(result);
        }

        [HttpGet("{contactUsId:long}")]
        [SwaggerOperation(Summary = "Get contact by Id")]
        public async Task<IActionResult> GetById(long contactUsId)
        {
            var contact = await _contactUsService.GetContactUsById(contactUsId);

            return HandleResult(contact);
        }


        [HttpDelete("{contactUsId:long}")]
        [SwaggerOperation(Summary = "Delete contact")]
        public async Task<IActionResult> Delete(long contactUsId)
        {
            var result = await _contactUsService.DeleteContactUs(contactUsId);

            return HandleResult(result);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Retrieve all contacts")]
        public async Task<IActionResult> GetAll()
        {
            var contacts = await _contactUsService.GetAll();

            return HandleResult(contacts);
        }

    }
}

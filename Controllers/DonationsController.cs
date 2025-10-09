using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using peace_kenya_api.Dtos.Donation;
using peace_kenya_api.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace peace_kenya_api.Controllers
{
    [Route("api/donations")]
    [ApiController]
    public class DonationsController : BaseController
    {
        private readonly IDonationService _donationService;

        public DonationsController(IDonationService donationService)
        {
            _donationService = donationService;
        }

        // submit donation, trigger STK Push

        [HttpPost]
        public async Task<IActionResult> CreateDonation([FromBody] CreateDonationDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _donationService.CreateDonation(dto);

            if (result.IsSuccess)
            {
                return CreatedAtAction(nameof(GetById), new { donationId = result.Data.DonationId }, result.Data);
            }

            return HandleResult(result);
        }

        [HttpGet("{donationId:long}")]
        [SwaggerOperation(Summary = "Get donation by Id")]
        public async Task<IActionResult> GetById(long donationId)
        {
            var donation = await _donationService.GetDonationById(donationId);

            return HandleResult(donation);
        }


        // admin
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _donationService.GetAll();
            return HandleResult(result);
        }
    }
}


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using peace_kenya_api.Services.Interfaces;

namespace peace_kenya_api.Controllers
{
    [Route("api/mpesa")]
    [ApiController]
    public class MpesaController : ControllerBase
    {
        private readonly IDonationService _donationService;
        private readonly ILogger<MpesaController> _logger;

        public MpesaController(IDonationService donationService, ILogger<MpesaController> logger)
        {
            _donationService = donationService;
            _logger = logger;
        }

        [HttpPost("callback")]
        public async Task<IActionResult> Callback([FromBody] dynamic payload)
        {
            try
            {
                var body = JsonConvert.DeserializeObject<JObject>(payload.ToString());
                var stk = body["Body"]?["stkCallback"];
                if (stk == null)
                    return BadRequest("Invalid payload");

                string checkoutId = stk["CheckoutRequestID"]?.ToString();
                int resultCode = (int)stk["ResultCode"];
                bool success = resultCode == 0;

                await _donationService.UpdateDonationStatus(checkoutId, success);

                _logger.LogInformation($"Callback processed: {checkoutId}, Success: {success}");
                return Ok(new { message = "Callback received successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Callback error");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using peace_kenya_api.Dtos.Beneficiary;
using peace_kenya_api.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace peace_kenya_api.Controllers
{
    [Route("api/beneficiaries")]
    [ApiController]
    public class BeneficiariesController : BaseController
    {
        private readonly IBeneficiaryService _beneficiaryService;

        public BeneficiariesController(IBeneficiaryService beneficiaryService)
        {
            _beneficiaryService = beneficiaryService;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create beneficiary")]
        public async Task<IActionResult> Create([FromBody] CreateBeneficiaryDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _beneficiaryService.CreateBeneficiary(dto);
            if (result.IsSuccess)
            {
                return CreatedAtAction(nameof(GetById), new { beneficiaryId = result.Data.BeneficiaryId }, result.Data);
            }
            return HandleResult(result);
        }

        [HttpGet("{beneficiaryId:long}")]
        [SwaggerOperation(Summary = "Get beneficiary by Id")]
        public async Task<IActionResult> GetById(long beneficiaryId)
        {
            var beneficiary = await _beneficiaryService.GetBeneficiaryById(beneficiaryId);

            return HandleResult(beneficiary);
        }

        [HttpDelete("{beneficiaryId:long}")]
        [SwaggerOperation(Summary = "Delete beneficiary")]
        public async Task<IActionResult> Delete(long beneficiaryId)
        {
            var result = await _beneficiaryService.DeleteBeneficiary(beneficiaryId);

            if (result.IsSuccess)
            {
                return NoContent();
            }
            return HandleResult(result);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Retrieve all beneficiaries")]
        public async Task<IActionResult> GetAll()
        {
            var beneficiaries = await _beneficiaryService.GetAll();

            return HandleResult(beneficiaries);
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update beneficiary")]
        public async Task<IActionResult> Update(long beneficiaryId, CreateBeneficiaryDto dto)
        {
            var beneficiary = await _beneficiaryService.UpdateBeneficiary(beneficiaryId, dto);
            return HandleResult(beneficiary);
        }
    }
}

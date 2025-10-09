using peace_kenya_api.Enums;

namespace peace_kenya_api.Dtos.Beneficiary
{
    public class BeneficiaryDto
    {
        public long  BeneficiaryId { get; set; }
        public string FisrtName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int IdNumber { get; set; }
        public string PassportNumber { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public Programs Programs { get; set; }
        public Skills Skills { get; set; }
        public Location Location { get; set; }
    }
}

using peace_kenya_api.Dtos.Donation;
using peace_kenya_api.Services.Interfaces;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using peace_kenya_api.Models.Mpesa;
using peace_kenya_api.Repositories.Interfaces;

namespace peace_kenya_api.Services.Implementation
{
    public class MpesaService : IMpesaService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<MpesaService> _logger;
        private readonly IDonationRepository _donationRepository;

        public MpesaService(IConfiguration configuration, ILogger<MpesaService> logger, IDonationRepository donationRepository)
        {
            _configuration = configuration;
            _logger = logger;
            _donationRepository = donationRepository;
        }

        public async Task<MpesaTokenModel> GenerateAccessToken()
        {
            string consumerKey = _configuration["Mpesa:ConsumerKey"];
            string consumerSecret = _configuration["Mpesa:ConsumerSecret"];

            var client = new RestClient("https://sandbox.safaricom.co.ke/oauth/v1/generate?grant_type=client_credentials");
            var request = new RestRequest();
            request.Method = Method.Get;
            var credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{consumerKey}:{consumerSecret}"));
            request.AddHeader("Authorization", $"Basic {credentials}");
            request.AddParameter("text/plain", "", ParameterType.RequestBody);

            var response = await client.ExecuteAsync(request);
            if (!response.IsSuccessful)
            {
                throw new Exception($"Failed to get access token: {response.Content}");
            }

            var token = JsonConvert.DeserializeObject<MpesaTokenModel>(response.Content);
            token.expiryTime = DateTime.Now.AddSeconds(Convert.ToDouble(token.expires_in));
            return token;
        }

        public async Task<string> InitiateStkPush(CreateDonationDto donation)
        {
            var token = await GenerateAccessToken();

            //var businessShortCode = _configuration["Mpesa:BusinessShortCode"];
            var businessShortCode = "174379";

            var passkey = _configuration["Mpesa:PassKey"];
            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            var password = Convert.ToBase64String(Encoding.UTF8.GetBytes(businessShortCode + passkey + timestamp));

            try
            {
                var payload = new StkPushModel
                {
                    BusinessShortCode = businessShortCode,
                    Password = password,
                    Timestamp = timestamp,
                    TransactionType = "CustomerPayBillOnline",
                    Amount = donation.Amount,
                    PartyA = donation.DonorPhone,
                    PartyB = businessShortCode,
                    PhoneNumber = donation.DonorPhone,
                    CallBackURL = _configuration["Mpesa:CallbackUrl"],
                    AccountReference = "Peace Kenya Donation",
                    TransactionDesc = "Donation Payment",
                };

                var client = new RestClient("https://sandbox.safaricom.co.ke/mpesa/stkpush/v1/processrequest");
                var request = new RestRequest();
                request.Method = Method.Post;
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", $"Bearer {token.access_token}");
                request.AddJsonBody(payload);

                var response = await client.ExecuteAsync(request);
                if (!response.IsSuccessful)
                {
                    throw new Exception($"STK Push failed: {response.Content}");
                }

                // deserialize 
                var result = JsonConvert.DeserializeObject<dynamic>(response.Content);

                return result.CheckoutRequestID;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initiating mpesa stk push");
                return "An error occurred while initiating mpesa stk push";
            }
        }
    }
}

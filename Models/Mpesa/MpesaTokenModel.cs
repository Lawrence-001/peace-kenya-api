﻿namespace peace_kenya_api.Models.Mpesa
{
    public class MpesaTokenModel
    {
        public string? access_token { get; set; }
        public string? expires_in { get; set; }
        public DateTime? expiryTime { get; set; }
    }
}

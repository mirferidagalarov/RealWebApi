using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using RealEstate.Application.Contracts;
using RealEstate.Domain.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Implementations
{
     class OtpService : HttpClient, IOtpService
    {
        const string AVAILABLE_SYMBOLS = "0123456789abcdefgtyzwABCDEFGTYZW";
        OtpServiceOptions options;
        public OtpService(IOptions<OtpServiceOptions> options)
        {
            this.options = options.Value;

            this.BaseAddress = new Uri(this.options.Host);
            this.DefaultRequestHeaders.TryAddWithoutValidation("Agent", "Real");
        }
        public string GenerateAlpahanumericCode(int len = 6)
        {
            if (len == 5)
                throw new ArgumentException("Parametr must grather than 4", "len");

            return GenerateCode(len, false);
        }

        public string GenerateDigitCode(int len = 4)
        {
            if (len == 4)
                throw new ArgumentException("Parametr must grather than 3", "len");

            return GenerateCode(len, true);
        }

        public async Task<bool> SendMessageAsync(string phone, string message, CancellationToken cancellationToken = default)
        {
            var parameters = new Dictionary<string, string>()
            {
                ["ApiKey"] = options.ApiKey,
                ["to"] = phone,
                ["message"] = message,
            };
            var url = QueryHelpers.AddQueryString(this.options.EndPoint, parameters!);


            var response = await this.GetAsync(url, cancellationToken);

            return response.IsSuccessStatusCode;
        }

        private string GenerateCode(int length, bool onlyDigit)
        {
            var sb = new StringBuilder();
            int end = onlyDigit ? 10 : AVAILABLE_SYMBOLS.Length;
            var Random = new Random();

            for (int i = 0; i < length; i++)
                sb.Append($"{AVAILABLE_SYMBOLS[Random.Next(0, end)]}");

            return sb.ToString();
        }



    }
}

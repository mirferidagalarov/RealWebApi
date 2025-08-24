using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Contracts
{
    public interface IOtpService
    {
        Task<bool> SendMessageAsync(string phone, string message, CancellationToken cancellationToken = default);
        string GenerateDigitCode(int len = 4);
        string GenerateAlpahanumericCode(int len = 6);
    }
}

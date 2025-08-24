using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Contracts
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(string to, string subject, string message, CancellationToken cancellationToken = default);
    }
}

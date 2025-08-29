using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Contracts;
using RealEstate.Application.Implementations;
using RealEstate.Application.Repositories;

namespace RealEstate.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController(ICityRepository cityRepository,
        IDateTimeService dateTimeService,
        IOtpService otpService,
        IEmailService emailService,
        ICryptoService cryptoService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = cityRepository.GetAll();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult GetAll(int id)
        {
            var data = cityRepository.Get(x => x.Id == id);
            return Ok(data);
        }

        [HttpGet("date")]
        public IActionResult GetDate()
        {
            var data = dateTimeService.Current.ToString("yyyy.MM.dd HH:mm:ss");
            return Ok(data);
        }

        // /api/cities/otp?phone= 528184760979
        [HttpGet("otp")]
        public async Task<IActionResult> SendOtp(string phone)
        {
            string otp = otpService.GenerateDigitCode(4);

            var isSuccess = await otpService.SendMessageAsync(phone, $"Your Real Estate OTP: {otp}");

            return Ok(isSuccess);
        }

        [HttpGet("email")]
        public async Task<IActionResult> SendEmail(string email)
        {
            string otp = otpService.GenerateDigitCode(4);

            string message = $"Sizin otp kod <b>{otp}</b>";

            var isSuccess = await emailService.SendEmailAsync(email, "Mir", message);

            return Ok(isSuccess);
        }

        [HttpGet("md5")]
        public async Task<IActionResult> MD5(string value)
        {
            string result = cryptoService.ToMd5(value);

            return Ok(result);
        }

        [HttpGet("sha1")]
        public async Task<IActionResult> Sha1(string value)
        {
            string result = cryptoService.ToSha1(value);

            return Ok(result);
        }
    }
}

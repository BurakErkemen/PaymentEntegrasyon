using Microsoft.AspNetCore.Mvc;
using Payment.Repository.DTO;
using Payment.Repository.Services;

namespace Payment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayController : ControllerBase
    {
        private readonly IPaymentServices _paymentService;
        private readonly ILogger<PayController> _logger;

        public PayController(IPaymentServices paymentService, ILogger<PayController> logger)
        {
            _paymentService = paymentService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Pay([FromBody] PaymentRequest request)
        {
            string ip = HttpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault()
            ?? HttpContext.Connection.RemoteIpAddress?.ToString()
            ?? "IP_BULUNAMADI";

            var userId = HttpContext.Items["UserId"]?.ToString();
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("Firebase kullanıcı doğrulaması başarısız.");
            }

            var response = await _paymentService.ProcessPaymentAsync(userId, request,ip);

            if (response.Code)
                return Ok(response);
            _logger.LogInformation("Kullanıcı ödeme yapıyor. IP: {ip}, UID: {userId}", ip, userId);

            return BadRequest(response);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Payment.Repository.DTO;
using Payment.Repository.Services;

namespace Payment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> Pay([FromBody] PaymentRequest request)
        {
            var userId = HttpContext.Items["UserId"]?.ToString();
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("Firebase kullanıcı doğrulaması başarısız.");
            }

            var response = await _paymentService.ProcessPaymentAsync(userId, request);

            if (response.Code)
                return Ok(response);

            return BadRequest(response);
        }
    }
}

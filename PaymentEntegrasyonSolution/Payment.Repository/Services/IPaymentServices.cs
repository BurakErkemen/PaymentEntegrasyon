using Payment.Repository.DTO;

namespace Payment.Repository.Services
{
    public interface IPaymentServices
    {
        Task<PaymentResponse> ProcessPaymentAsync(string userId, PaymentRequest request);
    }
}

using Payment.Repository.DTO;

namespace Payment.Repository.Services
{
    public interface IPaymentGateway
    {
        Task<PaymentResponse> MakePaymentAsync(PaymentRequest request, string ipAddress);
    }

}

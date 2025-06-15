using Payment.Repository.DTO;

namespace Payment.Repository
{
    public interface IIyzicoAdapter
    {
        Task<PaymentResponse> MakePaymentAsync(PaymentRequest request, string IPaddress);
    }
}

using Payment.Repository.DTO;

namespace Payment.Repository.Repository
{
    public interface IFirestoreRepository
    {
        Task SavePaymentAsync(string userId, PaymentRequest request, string paymentId);
    }
}

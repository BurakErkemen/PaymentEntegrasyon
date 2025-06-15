using Payment.Repository.Model;

namespace Payment.Repository.Repository
{
    public interface IFirestoreClient
    {
        Task AddPaymentAsync(string userId, PaymentModel payment);
    }
}

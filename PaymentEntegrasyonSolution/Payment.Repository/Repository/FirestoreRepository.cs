using Google.Cloud.Firestore;
using Payment.Repository.DTO;
using Payment.Repository.Model;
using System.Globalization;

namespace Payment.Repository.Repository
{
    public class FirestoreRepository : IFirestoreRepository
    {
        private readonly IFirestoreClient _client;

        public FirestoreRepository(IFirestoreClient client)
        {
            _client = client;
        }

        public async Task SavePaymentAsync(string userId, PaymentRequest request, string paymentId)
        {
            var payment = new PaymentModel
            {
                UserId = userId,
                PaymentId = paymentId,
                BuyerName = request.BuyerRequest.Name,
                Price = Convert.ToDouble(request.Price),
                CreatedAt = Timestamp.FromDateTime(DateTime.UtcNow)
            };

            await _client.AddPaymentAsync(userId, payment);
        }
    }
}

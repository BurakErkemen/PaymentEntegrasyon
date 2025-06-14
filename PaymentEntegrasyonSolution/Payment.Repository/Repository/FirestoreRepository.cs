using Google.Cloud.Firestore;
using Payment.Repository.DTO;
using Payment.Repository.Model;

namespace Payment.Repository.Repository
{
    public class FirestoreRepository : IFirestoreRepository
    {
        private readonly FirestoreDb _firestoreDb;

        public FirestoreRepository(FirestoreDb firestoreDb)
        {
            _firestoreDb = firestoreDb;
        }

        public async Task SavePaymentAsync(string userId, PaymentRequest request, string paymentId)
        {
            var payment = new PaymentModel
            {
                UserId = userId,
                PaymentId = paymentId,
                BuyerName = request.BuyerRequest.Name,
                Price = request.Price.ToString(),
                CreatedAt = Timestamp.GetCurrentTimestamp()
            };

            await _firestoreDb
                .Collection("users")
                .Document(userId)
                .Collection("payments")
                .AddAsync(payment);
        }
    }

}

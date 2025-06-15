using Google.Cloud.Firestore;
using Payment.Repository.Model;

namespace Payment.Repository.Repository
{
    public class FirestoreClient : IFirestoreClient
    {
        private readonly FirestoreDb _db;

        public FirestoreClient(FirestoreDb db)
        {
            _db = db;
        }

        public async Task AddPaymentAsync(string userId, PaymentModel payment)
        {
            await _db.Collection("users")
                     .Document(userId)
                     .Collection("payments")
                     .AddAsync(payment);
        }
    }
}

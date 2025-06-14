using Payment.Repository.DTO;
using Payment.Repository.Repository;

namespace Payment.Repository.Services
{
    public class PaymentService :IPaymentServices
    {
        private readonly IyzicoAdapter _iyzico;
        private readonly IFirestoreRepository _firestore;

        public PaymentService(IyzicoAdapter iyzico, IFirestoreRepository firestore)
        {
            _iyzico = iyzico;
            _firestore = firestore;
        }

        public async Task<PaymentResponse> ProcessPaymentAsync(string userId, PaymentRequest request)
        {
            var result = await _iyzico.MakePaymentAsync(request);
            if (result.Code == true)
            {
                await _firestore.SavePaymentAsync(userId, request, result.PaymentId);
            }

            return result;
        }
    }
}

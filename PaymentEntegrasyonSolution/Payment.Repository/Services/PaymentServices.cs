using Payment.Repository.DTO;
using Payment.Repository.Repository;
using Payment.Repository.Services;

public class PaymentService : IPaymentServices
{
    private readonly IPaymentGateway _paymentGateway;
    private readonly IFirestoreRepository _firestore;

    public PaymentService(IPaymentGateway paymentGateway, IFirestoreRepository firestore)
    {
        _paymentGateway = paymentGateway;
        _firestore = firestore;
    }

    public async Task<PaymentResponse> ProcessPaymentAsync(string userId, PaymentRequest request, string IPadress)
    {
        var result = await _paymentGateway.MakePaymentAsync(request, IPadress);
        if (result.Code)
        {
            await _firestore.SavePaymentAsync(userId, request, result.PaymentId);
        }

        return result;
    }
}

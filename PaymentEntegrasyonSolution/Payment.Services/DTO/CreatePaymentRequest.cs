using Iyzipay.Model;

namespace Payment.Repository.DTO;
public record CreatePaymentRequest(
    string Locale,
    string ConversationId,
    string Price,
    string PaidPrice,
    string Currency,
    string BasketId,
    string PaymentChannel,
    string PaymentGroup);

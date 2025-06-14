using Iyzipay.Model;
using static Google.Rpc.Context.AttributeContext.Types;

namespace Payment.Repository.DTO;
public record PaymentRequest(
    string Locale, // Locale.TR.ToString();
    string ConversationId, // "123456789",
    decimal Price, // "1.0", // Price is the total amount to be paid, e.g., "1.0" for 1 TRY
    decimal PaidPrice, // "1.0", // PaidPrice is the actual amount paid, e.g., "1.0" for 1 TRY
    string Currency , // Currency.TRY.ToString();
    short Installment,  // = 1;
    string PaymentChannel, // = PaymentChannel.WEB.ToString();
    string PaymentGroup, //= PaymentGroup.PRODUCT.ToString();
    CardRequest CardRequest,
    BuyerRequest BuyerRequest,
    ShippingAddressRequest ShippingAddressRequest,
    BillingAddressRequest BillingAddressRequest,
    BasketItemRequest BasketItemRequest

);
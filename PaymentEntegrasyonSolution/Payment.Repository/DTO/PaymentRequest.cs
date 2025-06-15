namespace Payment.Repository.DTO;
public record PaymentRequest(
    string ConversationId, // "123456789",
    decimal Price, // "1.0", // Price is the total amount to be paid, e.g., "1.0" for 1 TRY
    short Installment,  // = 1;
    CardRequest CardRequest,
    BuyerRequest BuyerRequest,
    ShippingAddressRequest ShippingAddressRequest,
    BillingAddressRequest BillingAddressRequest,
    BasketItemRequest BasketItemRequest
);
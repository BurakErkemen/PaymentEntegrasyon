using Payment.Repository.DTO;

namespace Payment.Tests.TestHelpers
{
    public static class TestDataFactory
    {
        public static PaymentRequest CreatePaymentRequest()
        {
            return new PaymentRequest(
                ConversationId: "123456789",
                Price: 1,
                Installment: 1,
                CardRequest: new CardRequest(
                    CardHolderName: "John Doe",
                    CardNumber: "5528790000000008",
                    ExpireMonth: "12",
                    ExpireYear: "2030",
                    Cvc: "123",
                    RegisterCard: "0"
                ),
                BuyerRequest: new BuyerRequest(
                    BuyerId: "BY789",
                    Name: "John",
                    Surname: "Doe",
                    GsmNumber: "+905350000000",
                    Email: "email@email.com",
                    IdentityNumber: "74300864791",
                    LastLoginDate: "2015-10-05 12:43:35",
                    RegistrationDate: "2013-04-21 15:12:09",
                    RegistrationAddress: "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
                    City: "İstanbul",
                    Country: "Turkey",
                    ZipCode: "34732"
                ),
                ShippingAddressRequest: new ShippingAddressRequest(
                    ContactName: "Jane Doe",
                    City: "Istanbul",
                    Country: "Turkey",
                    Description: "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
                    ZipCode: "34732"
                ),
                BillingAddressRequest: new BillingAddressRequest(
                    ContactName: "Jane Doe",
                    City: "Istanbul",
                    Country: "Turkey",
                    Description: "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
                    ZipCode: "34732"
                ),
                BasketItemRequest: new BasketItemRequest(
                    Id: "BI101",
                    Name: "Binocular",
                    Category1: "Collectibles",
                    Category2: "Accessories",
                    Price: 1
                )
            );
        }
    }
}

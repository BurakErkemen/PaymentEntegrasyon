using Payment.Repository.DTO;

public static class TestHelper
{
    public static PaymentRequest GenerateSamplePaymentRequest()
    {
        return new PaymentRequest(
            "123456789",
            1,
            1,
            new CardRequest("John Doe", "5528790000000008", "12", "2030", "123", "0"),
            new BuyerRequest("BY789", "John", "Doe", "+905350000000", "email@email.com", "74300864791",
                "2015-10-05 12:43:35", "2013-04-21 15:12:09", "Adres", "İstanbul", "Turkey", "34732"),
            new ShippingAddressRequest("Jane Doe", "Istanbul", "Turkey", "Adres", "34732"),
            new BillingAddressRequest("Jane Doe", "Istanbul", "Turkey", "Adres", "34732"),
            new BasketItemRequest("BI101", "Binocular", "Collectibles", "Accessories", 1)
        );
    }
}

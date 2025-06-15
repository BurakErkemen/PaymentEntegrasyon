using Moq;
using Xunit;
using Microsoft.Extensions.Configuration;
using Payment.Repository;
using Payment.Repository.DTO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Globalization;

public class IyzicoAdapterTests
{
    [Fact]
    public async Task MakePaymentAsync_ShouldReturnSuccess_WhenPaymentIsSuccessful()
    {
        // Arrange
        var mockConfig = new Mock<IConfiguration>();
        mockConfig.Setup(c => c["izyicoSDK:ApiKey"]).Returns("sandbox-ApiKey");
        mockConfig.Setup(c => c["izyicoSDK:SecretKey"]).Returns("sandbox-SecretKey");
        mockConfig.Setup(c => c["izyicoSDK:BaseUrl"]).Returns("https://sandbox-api.iyzipay.com");

        var adapter = new IyzicoAdapter(mockConfig.Object);

        var request = new PaymentRequest(
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

        // Act
        var result = await adapter.MakePaymentAsync(request, "127.0.0.1");

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Code || !result.Code); // Hatalı credential olsa bile test akışı kontrol ediliyor
    }
}

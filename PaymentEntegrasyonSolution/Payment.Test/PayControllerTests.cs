using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Payment.API.Controllers;
using Payment.Repository.DTO;
using Payment.Repository.Services; // Ekle

public class PayControllerTests
{
    [Fact]
    public async Task Pay_ShouldReturnOk_WhenPaymentSucceeds()
    {
        // Arrange
        var mockService = new Mock<IPaymentServices>();
        var mockLogger = new Mock<ILogger<PayController>>(); // 👈 Logger mock
        var dummyResponse = new PaymentResponse(true, "payment123", "OK");

        mockService.Setup(s => s.ProcessPaymentAsync(It.IsAny<string>(), It.IsAny<PaymentRequest>(), It.IsAny<string>()))
                   .ReturnsAsync(dummyResponse);

        var controller = new PayController(mockService.Object, mockLogger.Object); // 👈 Logger enjekte edildi

        var context = new DefaultHttpContext();
        context.Connection.RemoteIpAddress = System.Net.IPAddress.Parse("127.0.0.1");
        context.Items["UserId"] = "user123";
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = context
        };

        var request = TestHelper.GenerateSamplePaymentRequest();

        // Act
        var result = await controller.Pay(request);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsType<PaymentResponse>(okResult.Value);
        Assert.True(response.Code);
    }

    // Diğer testleri de aynı şekilde mockLogger ile güncelle:
    // var controller = new PayController(mockService.Object, mockLogger.Object);
}

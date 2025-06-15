using Moq;
using Payment.Repository.DTO;
using Payment.Repository.Repository;
using Payment.Repository.Services;
using Payment.Tests.TestHelpers;

public class PaymentServiceTests
{
    [Fact]
    public async Task ProcessPaymentAsync_ShouldReturnSuccess_AndCallSavePayment()
    {
        // Arrange
        var mockGateway = new Mock<IPaymentGateway>();
        var mockFirestore = new Mock<IFirestoreRepository>();

        var request = TestDataFactory.CreatePaymentRequest();
        string userId = "test-user";
        string ipAddress = "127.0.0.1";

        mockGateway.Setup(x => x.MakePaymentAsync(It.IsAny<PaymentRequest>(), ipAddress))
                   .ReturnsAsync(new PaymentResponse(true, "pay_123456", "OK"));

        var service = new PaymentService(mockGateway.Object, mockFirestore.Object);

        // Act
        var result = await service.ProcessPaymentAsync(userId, request, ipAddress);

        // Assert
        Assert.True(result.Code);
        Assert.Equal("pay_123456", result.PaymentId);
        Assert.Equal("OK", result.Message);
        mockFirestore.Verify(x => x.SavePaymentAsync(userId, request, "pay_123456"), Times.Once);
    }

    [Fact]
    public async Task ProcessPaymentAsync_ShouldReturnFailure_WhenIyzicoFails()
    {
        // Arrange
        var mockGateway = new Mock<IPaymentGateway>();
        var mockFirestore = new Mock<IFirestoreRepository>();

        var request = TestDataFactory.CreatePaymentRequest();
        string userId = "test-user";
        string ipAddress = "127.0.0.1";

        mockGateway.Setup(x => x.MakePaymentAsync(It.IsAny<PaymentRequest>(), ipAddress))
                   .ReturnsAsync(new PaymentResponse(false, null, "Kart reddedildi"));

        var service = new PaymentService(mockGateway.Object, mockFirestore.Object);

        // Act
        var result = await service.ProcessPaymentAsync(userId, request, ipAddress);

        // Assert
        Assert.False(result.Code);
        Assert.Null(result.PaymentId);
        Assert.Equal("Kart reddedildi", result.Message);
        mockFirestore.Verify(x => x.SavePaymentAsync(It.IsAny<string>(), It.IsAny<PaymentRequest>(), It.IsAny<string>()), Times.Never);
    }
}

using Moq;
using Payment.Repository.DTO;
using Payment.Repository.Model;
using Payment.Repository.Repository;
using Xunit;

public class FirestoreRepositoryTests
{
    [Fact]
    public async Task SavePaymentAsync_ShouldCallAddAsync_WithCorrectData()
    {
        // Arrange
        var mockClient = new Mock<IFirestoreClient>();
        var repository = new FirestoreRepository(mockClient.Object);

        var request = TestHelper.GenerateSamplePaymentRequest();

        // Act
        await repository.SavePaymentAsync("user123", request, "payment123");

        // Assert
        mockClient.Verify(c => c.AddPaymentAsync("user123",
            It.Is<PaymentModel>(p =>
                p.UserId == "user123" &&
                p.PaymentId == "payment123" &&
                p.BuyerName == request.BuyerRequest.Name &&
                p.Price == Convert.ToDouble(request.Price)
            )), Times.Once);
    }
}

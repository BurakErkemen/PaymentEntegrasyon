using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Payment.Repository.DTO;
using System.Globalization;
using Microsoft.Extensions.Configuration;

namespace Payment.Repository
{
    public class IyzicoAdapter
    {
        private readonly IConfiguration _configuration;

        public IyzicoAdapter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<PaymentResponse> MakePaymentAsync(PaymentRequest request)
        {
            var options = new Options
            {
                ApiKey = _configuration["izyicoSDK:ApiKey"],
                SecretKey = _configuration["izyicoSDK:SecretKey"],
                BaseUrl = _configuration["izyicoSDK:BaseUrl"]
            };

            var paymentRequest = new CreatePaymentRequest
            {
                Locale = Locale.TR.ToString(),
                Price = request.Price.ToString("F2", CultureInfo.InvariantCulture),
                PaidPrice = request.Price.ToString("F2", CultureInfo.InvariantCulture),
                Currency = Currency.TRY.ToString(),
                Installment = 1,
                PaymentChannel = PaymentChannel.WEB.ToString(),
                PaymentGroup = PaymentGroup.PRODUCT.ToString(),
                PaymentCard = new PaymentCard
                {
                    CardHolderName = request.CardRequest.CardHolderName,
                    CardNumber = request.CardRequest.CardNumber,
                    ExpireMonth = request.CardRequest.ExpireMonth,
                    ExpireYear = request.CardRequest.ExpireYear,
                    Cvc = request.CardRequest.Cvc,
                    RegisterCard = 0
                },
                Buyer = new Buyer
                {
                    Id = "BY789",
                    Name = "Test",
                    Surname = "User",
                    Email = "test@example.com"
                },
                BillingAddress = new Address
                {
                    ContactName = "Test User",
                    City = "Istanbul",
                    Country = "Turkey",
                    Description = "Address"
                },
                BasketItems = new List<BasketItem>
                {
                    new BasketItem
                    {
                        Id = "BI101",
                        Name = "Item",
                        Category1 = "Category",
                        ItemType = BasketItemType.VIRTUAL.ToString(),
                        Price = request.Price.ToString("F2", CultureInfo.InvariantCulture)
                    }
                }
            };

            var payment = await Task.Run(() => Iyzipay.Model.Payment.Create(paymentRequest, options));

            return new PaymentResponse(
                Code: payment.Status == "success",
                PaymentId: payment.PaymentId,
                Message: payment.ErrorMessage ?? "OK"
            );
        }
    }
}

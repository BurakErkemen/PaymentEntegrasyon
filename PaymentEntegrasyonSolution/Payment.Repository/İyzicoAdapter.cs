using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Payment.Repository.DTO;
using System.Globalization;
using System.Net.Http;

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
                    Id = request.BuyerRequest.BuyerId,
                    Name = request.BuyerRequest.Name,
                    Surname = request.BuyerRequest.Surname,
                    GsmNumber = request.BuyerRequest.GsmNumber,
                    Email = request.BuyerRequest.Email,
                    IdentityNumber = request.BuyerRequest.IdentityNumber,
                    LastLoginDate = request.BuyerRequest.LastLoginDate.ToDateTime().ToString("yyyy-MM-dd HH:mm:ss"),
                    RegistrationDate = request.BuyerRequest.RegistrationDate.ToDateTime().ToString("yyyy-MM-dd HH:mm:ss"),
                    RegistrationAddress = request.BuyerRequest.RegistrationAddress,
                    Ip = request.BuyerRequest.Ip,
                    City = request.BuyerRequest.City,
                    Country = request.BuyerRequest.Country,
                    ZipCode = request.BuyerRequest.ZipCode
                },
                BillingAddress = new Address
                {
                    ContactName = request.BillingAddressRequest.ContactName,
                    City = request.BillingAddressRequest.City,
                    Country = request.BillingAddressRequest.Country,
                    Description = request.BillingAddressRequest.Description,
                    ZipCode = request.BillingAddressRequest.ZipCode
                },
                ShippingAddress = new Address
                {
                    ContactName = request.ShippingAddressRequest.ContactName,
                    City = request.ShippingAddressRequest.City,
                    Country = request.ShippingAddressRequest.Country,
                    Description = request.ShippingAddressRequest.Description,
                    ZipCode = request.ShippingAddressRequest.ZipCode
                },
                BasketItems = new List<BasketItem>
                {
                    new BasketItem
                    {
                        Id = request.BasketItemRequest.Id,
                        Name = request.BasketItemRequest.Name,
                        Category1 = request.BasketItemRequest.Category1,
                        Category2 = request.BasketItemRequest.Category2,
                        ItemType = BasketItemType.VIRTUAL.ToString(),
                        Price = request.BasketItemRequest.Price.ToString("F2", CultureInfo.InvariantCulture)
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

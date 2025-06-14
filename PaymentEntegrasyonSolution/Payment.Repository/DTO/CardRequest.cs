using Iyzipay.Model;

namespace Payment.Repository.DTO;
public record CardRequest(
    string CardHolderName, //= "John Doe";
    string CardNumber, // = "5528790000000008";
    string ExpireMonth, // = "12";
    string ExpireYear, // = "2030";
    string Cvc, // = "123";
    string RegisterCard //= 0;
    );
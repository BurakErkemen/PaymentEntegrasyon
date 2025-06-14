namespace Payment.Repository.DTO;
public record ShippingAddressRequest
    (
string ContactName, //= "Jane Doe";
string City, // = "Istanbul";
string Country,//  = "Turkey";
string Description, // = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
string ZipCode // = "34742";
    );
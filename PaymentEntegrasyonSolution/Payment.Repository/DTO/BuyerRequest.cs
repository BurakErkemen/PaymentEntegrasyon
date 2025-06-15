using Google.Cloud.Firestore;

namespace Payment.Repository.DTO;
public record BuyerRequest(
    string BuyerId, // = "BY789";
    string Name, // = "John";
    string Surname, //  = "Doe";
    string GsmNumber, // = "+905350000000";
    string Email, //  = "email@email.com";
    string IdentityNumber, // = "74300864791";
    string LastLoginDate, // = "2015-10-05 12:43:35";
    string RegistrationDate, // = "2013-04-21 15:12:09";
    string RegistrationAddress, //= "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
    string City,// = "Istanbul";
    string Country, // = "Turkey";
    string ZipCode// = "34732";
    );
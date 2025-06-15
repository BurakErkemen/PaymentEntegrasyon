namespace Payment.Repository.DTO;
public record BasketItemRequest(
    string Id,  //= "BI101";
    string Name, // = "Binocular";
    string Category1, // = "Collectibles";
    string Category2, // = "Accessories";
    decimal Price // = "0.3";
    );
 

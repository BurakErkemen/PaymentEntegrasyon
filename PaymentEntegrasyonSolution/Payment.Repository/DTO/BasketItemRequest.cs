namespace Payment.Repository.DTO;
public record BasketItemRequest(
    string Id,  //= "BI101";
string Name, // = "Binocular";
string Category1, // = "Collectibles";
string Category2, // = "Accessories";
string ItemTyp, //e = BasketItemType.PHYSICAL.ToString();
string Price // = "0.3";
    );
 

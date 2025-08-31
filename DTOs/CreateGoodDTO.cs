namespace ItalyShopAPI.DTOs
{
    public class CreateGoodDTO
    {
        public string GName { get; set; }
        public int CategoryFk { get; set; }
        public string Model { get; set; }
        public int GQuantity { get; set; }
        public double Price { get; set; }
        public int Sale { get; set; }
        public string Image { get; set; }
        public bool IsNew { get; set; }
    }
}

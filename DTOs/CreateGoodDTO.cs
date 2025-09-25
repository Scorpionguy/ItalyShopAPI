using ItalyShopAPI.Models;

namespace ItalyShopAPI.DTOs
{
    public class CreateGoodDTO
    {
        public string GName { get; set; }
        public int CategoryFk { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Charasteristics { get; set; }
        public ICollection<CreateSizeDTO> sizes { get; set; } = null!;
    }
}

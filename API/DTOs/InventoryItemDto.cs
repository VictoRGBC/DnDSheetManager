namespace DnDSheetManager.API.DTOs
{
    public class InventoryItemDto
    {
        public int ItemId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public double TotalWeight { get; set; }
    }
}
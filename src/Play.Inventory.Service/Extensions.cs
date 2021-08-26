using Play.Inventory.Service.Dtos;

namespace Play.Inventory.Service
{
    public static class Extensions
    {

        public static InventoryItemDto AsDto(this Entities.InventoryItem item)
        {
            return new InventoryItemDto(item.CatalogItemId,item.Quantity, item.AcquiredDate);
        }
        
    }
    
}
using System;
using Play.Common;

namespace Play.Inventory.Service.Entities
{

    public class CatalogItem : IEntity
    {

        #region Properties

            
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        
        #endregion
    }

}
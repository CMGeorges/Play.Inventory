using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MassTransit;
using Play.Catalog.Contracts;
using Play.Common;
using Play.Inventory.Service.Entities;

namespace Play.Inventory.Service.Consumers
{

    public class CatalogItemUpdatedConsumer : IConsumer<CatalogItemUpdated>
    {

        #region Attributes
        private readonly IRepository<CatalogItem> _repository;

        #endregion

        #region Ctor
        public CatalogItemUpdatedConsumer(IRepository<CatalogItem> repository)
        {
            this._repository = repository;
        }

        #endregion


        #region Public methods
        public async Task Consume(ConsumeContext<CatalogItemUpdated> context)
        {
            var message = context.Message;

            var item = await _repository.GetAsync(message.ItemId);

            if (item == null)
            {
                item = new CatalogItem
                {
                    Id = message.ItemId,
                    Name = message.Name,
                    Description = message.Description
                };

                await _repository.UpdateAsync(item);
            }
            else
            {
                item.Name = message.Name;
                item.Description = message.Description;

                await _repository.UpdateAsync(item);
            }


        }



        #endregion

    }

}
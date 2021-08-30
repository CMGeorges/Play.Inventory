using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MassTransit;
using Play.Catalog.Contracts;
using Play.Common;
using Play.Inventory.Service.Entities;

namespace Play.Inventory.Service.Consumers
{

    public class CatalogItemDeletedConsumer  : IConsumer<CatalogItemDeleted>
    {

        #region Attributes
        private readonly IRepository<CatalogItem> _repository;

        #endregion

        #region Ctor
        public CatalogItemDeletedConsumer(IRepository<CatalogItem> repository)
        {
            this._repository = repository;
        }

        #endregion


        #region Public methods
        public async Task Consume(ConsumeContext<CatalogItemDeleted> context)
        {
            var message = context.Message;

            var item = await _repository.GetAsync(message.ItemId);

            if (item == null)
            {
               return;
            }

            await _repository.RemoveAsync(item.Id);


        }



        #endregion

    }

}
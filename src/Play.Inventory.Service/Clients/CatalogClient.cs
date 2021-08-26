using System.Collections.Generic;
using System.Threading.Tasks;
using Play.Inventory.Service.Dtos;
using System.Net.Http;
using System.Net.Http.Json;

namespace Play.Inventory.Service.Clients
{

    public class CatalogClient
    {

        #region Parameters
        private readonly HttpClient _httpClient;


        #endregion

        #region Ctor

        public CatalogClient(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
            
        #endregion

        #region Public functions

        public async Task<IReadOnlyCollection<CatalogItemDto>> GetCatalogItemsAsync()
        {
            var items = await _httpClient.GetFromJsonAsync<IReadOnlyCollection<CatalogItemDto>>("/items");
            return items;
        }

        #endregion
    }
    
}
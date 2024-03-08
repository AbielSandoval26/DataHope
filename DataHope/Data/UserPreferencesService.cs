using Cosmonaut;
using LibraryDataModel;
using Microsoft.Azure.Documents;
using System.Threading.Tasks;

namespace DataHope.Data
{
    public class UserPreferencesService
    {
        private readonly ICosmosStore<UserPreferencesModel> _userPreferencesStore;
        public UserPreferencesService(ICosmosStore<UserPreferencesModel> expenseStore)
        {
            _userPreferencesStore = expenseStore;
        }

        public async Task<Cosmonaut.Response.CosmosResponse<UserPreferencesModel>> UpsertUserPreferences(UserPreferencesModel userPreferences)
        {
            var result = await _userPreferencesStore.UpsertAsync(userPreferences);
            return result;
        }

        public async Task<UserPreferencesModel> GetUserPreferences(string email)
        {

            var result = await _userPreferencesStore.FindAsync(email, new Microsoft.Azure.Documents.Client.RequestOptions { PartitionKey = PartitionKey.None });
            return result;
        }
    }
}

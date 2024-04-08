#if NETSTANDARD
using Cosmonaut;
using Cosmonaut.Attributes;
#endif
using Newtonsoft.Json;

namespace LibraryDataModel
{
#if NETSTANDARD
    [SharedCosmosCollection("shared", "userpreferences")]
    public class UserPreferencesModel : ISharedCosmosEntity
#else
    public class UserPreferencesModel
#endif
    {
        [JsonIgnore]
        public string CosmosEntityName { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        public string Email { get; set; }

    }
}

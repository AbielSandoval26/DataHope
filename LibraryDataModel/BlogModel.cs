#if NETSTANDARD
using Cosmonaut;
using Cosmonaut.Attributes;
#endif
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryDataModel
{
#if NETSTANDARD
    [SharedCosmosCollection("shared", "blog")]
    public class BlogModel : ISharedCosmosEntity
#else
    public class BlogModel
#endif
    {
        [JsonIgnore]
        public string CosmosEntityName { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }

        public string Title { get; set; }
        public string Introduction { get; set; }
        public string Body { get; set; }
        public string Image {  get; set; }
    }
}

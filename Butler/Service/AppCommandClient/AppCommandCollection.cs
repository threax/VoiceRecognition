using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butler.Service.AppCommand.Client
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class AppCommandCollection
    {
        /// <summary>The number of pages (item number = Offset * Limit) into the collection to query.</summary>
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }

        /// <summary>Lookup a buttonState by id.</summary>
        [Newtonsoft.Json.JsonProperty("appCommandId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? AppCommandId { get; set; }

        [Newtonsoft.Json.JsonProperty("total", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Total { get; set; }

        /// <summary>The limit of the number of items to return.</summary>
        [Newtonsoft.Json.JsonProperty("limit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Limit { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static AppCommandCollection FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<AppCommandCollection>(data);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butler.Service.AppCommand.Client
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class AppCommand
    {
        [Newtonsoft.Json.JsonProperty("appCommandId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid AppCommandId { get; set; }

        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    }
}

using Butler.Service.AppCommand.Client;
using System;
using Threax.AspNetCore.Models;

namespace Butler.ModelSchemas
{
    public class AppCommandLink
    {
        [NoInputModel]
        [NoViewModel]
        public String Json { get; set; }

        [DefineValueProvider(typeof(AppCommandValueProvider))]
        public Guid AppCommandId { get; set; }
    }
}

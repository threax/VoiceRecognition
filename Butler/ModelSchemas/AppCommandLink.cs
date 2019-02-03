using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Models;

namespace Butler.ModelSchemas
{
    public class AppCommandLink
    {
        [NoInputModel]
        [NoViewModel]
        public String Json { get; set; }

        public AppCommandSet CommandSet { get; set; }
    }
}

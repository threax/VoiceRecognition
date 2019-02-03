using Butler.Models;
using Butler.Service.AppCommand.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Threax.AspNetCore.Models;

namespace Butler.ModelSchemas
{
    public abstract class AppCommandSet
    {
        [Required]
        [MaxLength(450)]
        public String Name { get; set; }

        [MaxLength(2000)]
        public String VoicePrompt { get; set; }

        [MaxLength(2000)]
        public String Response { get; set; }

        [MaxLength(10)]
        public String Key { get; set; }

        public KeyModifier Modifier { get; set; }

        [DefineValueProvider(typeof(AppCommandValueProvider))]
        public Guid AppCommandId { get; set; }

        [NoInputModel]
        [NoViewModel]
        public String Json { get; set; }
    }
}

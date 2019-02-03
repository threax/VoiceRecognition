using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;
using Threax.AspNetCore.Tracking;
using Butler.Models;

namespace Butler.Database 
{
    public partial class AppCommandSetEntity : IAppCommandSet, IAppCommandSetId, ICreatedModified
    {
        [Key]
        public Guid AppCommandSetId { get; set; }

        [Required(ErrorMessage = "Name must have a value.")]
        [MaxLength(450, ErrorMessage = "Name must be less than 450 characters.")]
        public String Name { get; set; }

        [MaxLength(2000, ErrorMessage = "Voice Prompt must be less than 2000 characters.")]
        public String VoicePrompt { get; set; }

        [MaxLength(2000, ErrorMessage = "Response must be less than 2000 characters.")]
        public String Response { get; set; }

        [MaxLength(10, ErrorMessage = "Key must be less than 10 characters.")]
        public String Key { get; set; }

        public KeyModifier Modifier { get; set; }

        public List<AppCommandLinkEntity> AppCommandLinks { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

    }
}

using Microsoft.Build.Framework;

namespace Business.Areas.Admin.ViewModels.Team
{
    public class TeamCreateVM
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public IFormFile Photo { get; set; }
        [Required]
        public string Position { get; set; }
    }
}

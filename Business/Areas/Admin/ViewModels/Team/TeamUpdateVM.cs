using System.ComponentModel.DataAnnotations;

namespace Business.Areas.Admin.ViewModels.Team
{
    public class TeamUpdateVM
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public IFormFile? Photo { get; set; }
        [Required]
        public string Position { get; set; }
    }
}

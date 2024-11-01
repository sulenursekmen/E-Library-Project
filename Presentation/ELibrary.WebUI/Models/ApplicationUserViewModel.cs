namespace ELibrary.WebUI.Models
{
    public class ApplicationUserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public bool? IsActive { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? Bio { get; set; }
    }
}

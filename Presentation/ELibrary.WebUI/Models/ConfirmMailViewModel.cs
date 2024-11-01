using System.ComponentModel.DataAnnotations;

namespace ELibrary.WebUI.Models
{
    public class ConfirmMailViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Onay kodu gereklidir.")]
        public string ConfirmCode { get; set; }
    }
}

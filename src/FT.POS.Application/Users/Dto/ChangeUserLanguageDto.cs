using System.ComponentModel.DataAnnotations;

namespace FT.POS.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
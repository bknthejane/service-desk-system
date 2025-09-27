using System.ComponentModel.DataAnnotations;

namespace Nthware.SDS.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
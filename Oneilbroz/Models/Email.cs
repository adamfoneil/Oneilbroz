using System.ComponentModel.DataAnnotations;

namespace Oneilbroz.Models
{
    public class Email
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        public string Value { get; set; } = string.Empty;
    }
}

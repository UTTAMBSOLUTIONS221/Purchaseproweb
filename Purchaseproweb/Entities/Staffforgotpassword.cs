using System.ComponentModel.DataAnnotations;

namespace Purchaseproweb.Entities
{
    public class Staffforgotpassword
    {
        [Required(ErrorMessage = "Email Address Is Required!")]
        public string? EmailAddress { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace backend.RemodelKing.Resources;

public class SavePaymentResource
{
    [Required]
    public long CreditCard { get; set; }
    [Required]
    public string ExpiryDate { get; set; }
    [Required]
    public string CardHolder { get; set; }
    [Required]
    public string CardIssuer { get; set; }
    [Required]
    public string CVV { get; set; }
    public long BusinessId { get; set; }
}
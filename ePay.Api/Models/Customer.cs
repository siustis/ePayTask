using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ePay.Api.Models;

public class Customer
{
    [Key]
    [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    [Required]
    public string? FirstName { get; set; }

    [Required]
    public string? LastName { get; set; }

    [Range(18, 90, ErrorMessage = "Age must be between 18 and 90")]
    public int Age { get; set; }
}

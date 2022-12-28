using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{
    [Index(nameof(Firstname), nameof(Lastname), nameof(DateOfBirth), IsUnique = true)]
    public class Customer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)] [Required] public string Firstname { get; set; }
        [MaxLength(50)] [Required] public string Lastname { get; set; }
        [MaxLength(50)] [Required] public DateTime DateOfBirth { get; set; }
        [MaxLength(15)] [Required] public string PhoneNumber { get; set; }
        [MaxLength(50)] [Required] public string Email { get; set; }
        [MaxLength(50)] [Required] public string BankAccountNumber { get; set; }
    }
}
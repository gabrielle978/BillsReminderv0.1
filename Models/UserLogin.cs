using System.ComponentModel.DataAnnotations;

namespace BillsReminder.Models
{
    public class UserLogin
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }

    }
}

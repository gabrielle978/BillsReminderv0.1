using System.ComponentModel.DataAnnotations;

namespace BillsReminder.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required(ErrorMessage ="Crie uma senha")]
        public string Senha { get; set; }
    }
}

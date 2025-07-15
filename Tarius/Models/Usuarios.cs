using System.ComponentModel.DataAnnotations;

namespace Tarius.Models
{
    public class Usuarios
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Correo no v�lido")]
        public required string Correo { get; set; }

        [Required(ErrorMessage = "La contrase�a es obligatoria")]
        [MinLength(8, ErrorMessage = "La contrase�a debe tener al menos 8 caracteres")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*]).+$",
            ErrorMessage = "Debe tener al menos una may�scula, un n�mero y un car�cter especial")]
        public required string Contrase�a { get; set; }

        public required string Rol { get; set; }

    }
}

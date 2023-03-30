using System.ComponentModel.DataAnnotations;

namespace FantasyGame.Endpoints.Times
{
    public class TimeInputModel
    {
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Nome do time precisa conter no mínimo 3 caracteres e no máximo 255")]
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }
    }
}

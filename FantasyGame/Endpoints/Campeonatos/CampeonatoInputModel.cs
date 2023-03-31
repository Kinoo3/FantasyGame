using System.ComponentModel.DataAnnotations;

namespace FantasyGame.Endpoints.Campeonatos
{
    public class CampeonatoInputModel
    {
        [StringLength(255, MinimumLength = 5, ErrorMessage = "Nome do campeonato precisa conter no mínimo 5 caracteres e no máximo 255")]
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; } = string.Empty;
    }
}

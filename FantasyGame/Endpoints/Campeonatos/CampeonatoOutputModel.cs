using FantasyGame.Models;
using FantasyGame.Models.Data.Entities;

namespace FantasyGame.Endpoints.Campeonatos
{
    public class CampeonatoOutputModel : BaseResponseModel
    {
        public CampeonatoOutputModel(bool success, string campeonatoNome, string campeao, string vice, string terceiro, IList<PartidaDTO> partidas) 
        { 
            Success = success;
            Response = new CampeonatoResponse(campeonatoNome, campeao, vice, terceiro, partidas);
        }
    }

    public class CampeonatoResponse : IResponse
    {
        public string CampeonatoNome { get; set; }
        public string Campeao { get; set; }
        public string Vice { get; set; }
        public string Terceiro { get; set; }
        public IList<PartidaDTO> Partidas { get; set; }

        public CampeonatoResponse(string campeonatoNome, string campeao, string vice, string terceiro, IList<PartidaDTO> partidas)
        {
            CampeonatoNome = campeonatoNome;
            Campeao = campeao;
            Vice = vice;
            Terceiro = terceiro;
            Partidas = partidas;
        }
    }

    public class PartidaDTO
    {
        public string Times { get; set; }
        public string Resultado { get; set; }
    }

    public class TimeScoreDTO
    {
        public Time time { get; set; }
        public int Score { get; set; }
    }
}

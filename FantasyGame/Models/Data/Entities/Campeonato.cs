namespace FantasyGame.Models.Data.Entities
{
    public class Campeonato : BaseEntity
    {
        public string Nome { get; set; }
        public DateTime DataRealizacao {  get; set; }
        public ICollection<Partida> Partidas { get; set; }
    }
}

namespace FantasyGame.Models.Data.Entities
{
    public class Partida : BaseEntity
    {

        public Time Time1 { get; set; }
        public int Time1Gols { get; set; }

        public Time Time2 { get; set; }
        public int Time2Gols { get; set; }

        public Campeonato Campeonato { get; set; }

        public DateTime Data {  get; set; }
    }
}

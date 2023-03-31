using FantasyGame.Models;
using FantasyGame.Models.Data.DataAcessLayer.UnitOfWork;
using FantasyGame.Models.Data.Entities;
using FantasyGame.Utils;
using System.Configuration;

namespace FantasyGame.Endpoints.Campeonatos
{
    public class CampeonatoBusinessRule
    {
        private readonly IUnitOfWork _unitOfWork;
        public CampeonatoBusinessRule(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IBaseResponseModel> GetCampeonatoById(int id)
        {
            try
            {
                Campeonato? campeonato = await _unitOfWork._campeonatoRepository.GetByIdAsyncInclude(id);
                if (campeonato == null)
                {
                    return new FailedResponseModel(false, "Nenhum campeonato com esse ID foi encontrado no sistema");
                }
                return CalcScoreCampeonato(campeonato);
            }
            catch (Exception)
            {
                return new FailedResponseModel(false, "Erro ao buscar campeonato");
            }
        }

        public async Task<IBaseResponseModel> GetCampeonatosPaginated(PaginatedSearchInputModel input)
        {
            PaginationValidator pagination = new PaginationValidator(input.Pagina, input.TamanhoPagina);

            try
            {
                var campeonatos = await _unitOfWork._campeonatoRepository.GetPaginated(pagination.Skip, pagination.Take);


                var totalRecords = await _unitOfWork._campeonatoRepository.CountTotalRecords();

                int totalPages = (totalRecords + pagination.PageSize - 1) / pagination.PageSize;

                return new GetPagedResponse<Campeonato>(true, pagination.Page, pagination.PageSize, totalPages, campeonatos);
            }
            catch (Exception)
            {
                return new FailedResponseModel(false, "Não foi possível retornar a lista de times");
            }
        }


        public async Task<IBaseResponseModel> GetMostRecentCampeonato()
        {
            try
            {
                var campeonato = await _unitOfWork._campeonatoRepository.GetMostRecent();
                if (campeonato == null)
                {
                    return new FailedResponseModel(false, "Não existe nenhum campeonato no sistema");
                }
                else return CalcScoreCampeonato(campeonato);
            }
            catch (Exception)
            {
                return new FailedResponseModel(false, "Erro ao realizar campeonato");
            }
        }

        public async Task<IBaseResponseModel> RealizarCampeonato(CampeonatoInputModel input)
        {
            Campeonato campeonato = new Campeonato() { Nome = input.Nome };
            campeonato.Partidas = new List<Partida>();
            campeonato.DataRealizacao = DateTime.Now;

            try
            {
                var times = await _unitOfWork._timeRepository.GetAll();


                List<PartidaDTO> partidasOutput = new List<PartidaDTO>();
                //Cria pares únicos dado a lista de times, sem criar par com o próprio elemento
                for (int j = 0; j < times.Count; j++)
                {
                    for (int k = j + 1; k < times.Count; k++)
                    {
                        Partida partida = new Partida();
                        partida.Time1 = times[j];
                        partida.Time1Gols = RandomNumberGols();
                        partida.Time2 = times[k];
                        partida.Time2Gols = RandomNumberGols();
                        partida.Data = DateTime.Now;

                        campeonato.Partidas.Add(partida);
                    }
                }
                await _unitOfWork._campeonatoRepository.AddAsync(campeonato);
                _unitOfWork.Save();

                return CalcScoreCampeonato(campeonato);
            }
            catch (Exception)
            {
                return new FailedResponseModel(false, "Erro ao realizar campeonato");
            }
        }

        public int RandomNumberGols()
        {
            Random rndom = new Random();
            return rndom.Next(0, 9);
        }

        //Dado um campeonato, calcula a pontuação de cada time, e retorna as informações derivadas do campeonato
        public IBaseResponseModel CalcScoreCampeonato(Campeonato campeonato)
        {
            var listaTimes = new List<TimeScoreDTO>();
            List<PartidaDTO> partidasOutput = new List<PartidaDTO>();

            foreach (var partida in campeonato.Partidas)
            {
                if (!listaTimes.Any(y => y.time == partida.Time1))
                {
                    listaTimes.Add(new TimeScoreDTO() { time = partida.Time1, Score = 0 });
                }
                if (!listaTimes.Any(y => y.time == partida.Time2))
                {
                    listaTimes.Add(new TimeScoreDTO() { time = partida.Time2, Score = 0 });
                }


                partidasOutput.Add(new PartidaDTO()
                {
                    Times = partida.Time1.Nome + " x " + partida.Time2.Nome,
                    Resultado = partida.Time1Gols + " x " + partida.Time2Gols
                });


                if (partida.Time1Gols > partida.Time2Gols)
                {
                    var time1 = listaTimes.First(x => x.time.Id == partida.Time1.Id);
                    time1.Score += 3;
                }
                else if (partida.Time2Gols > partida.Time1Gols)
                {
                    var time2 = listaTimes.First(x => x.time.Id == partida.Time2.Id);
                    time2.Score += 3;
                }
                else
                {
                    var time1 = listaTimes.First(x => x.time.Id == partida.Time2.Id);
                    var time2 = listaTimes.First(x => x.time.Id == partida.Time2.Id);
                    time1.Score += 1;
                    time2.Score += 1;
                }
            }

            string campeao = listaTimes.OrderByDescending(time => time.Score).First().time.Nome;
            string vice = listaTimes.OrderByDescending(time => time.Score).Skip(1).First().time.Nome;
            string terceiro = listaTimes.OrderByDescending(time => time.Score).Skip(2).First().time.Nome;

            return new CampeonatoOutputModel(true, campeonato.Nome, campeao, vice, terceiro, partidasOutput);
        }
    }
}
using FantasyGame.Database;
using FantasyGame.Models;
using FantasyGame.Models.Data.DataAcessLayer;
using FantasyGame.Models.Data.DataAcessLayer.UnitOfWork;
using FantasyGame.Models.Data.Entities;
using FantasyGame.Utils;
using System.Linq.Expressions;

namespace FantasyGame.Endpoints.Times
{
    public class TimeBusinessRule
    {
        private readonly IUnitOfWork _unitOfWork;
        public TimeBusinessRule(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IBaseResponseModel> GetTimeById(int Id)
        {
            try
            {
                Time? time = await _unitOfWork._timeRepository.GetByIdAsync(Id);
                if (time == null)
                {
                    return new FailedResponseModel(false, "Nenhum time com esse ID foi encontrado no sistema");
                }
                return new GetEntityResponseModel<Time>(true, time);
            }
            catch (Exception)
            {
                return new FailedResponseModel(false, "Erro ao buscar time");
            }
        }

        public async Task<IBaseResponseModel> GetTimes(PaginatedSearchInputModel input)
        {
            PaginationValidator pagination = new PaginationValidator(input.Pagina, input.TamanhoPagina);

            try
            {
                var times = await _unitOfWork._timeRepository.GetPaginated(pagination.Skip, pagination.Take);


                var totalRecords = await _unitOfWork._timeRepository.CountTotalRecords();

                int totalPages = (totalRecords + pagination.PageSize - 1) / pagination.PageSize;

                return new GetPagedResponse<Time>(true, pagination.Page, pagination.PageSize, totalPages, times);
            }
            catch (Exception)
            {
                return new FailedResponseModel(false, "Não foi possível retornar a lista de times");
            }
        }

        public async Task<IBaseResponseModel> CreateTime(TimeInputModel timeInput)
        {

            Time time = new Time { Nome = timeInput.Nome };

            try
            {
                if (_unitOfWork._timeRepository.NameAlreadyExists(time.Nome))
                {
                    return new FailedResponseModel(false, "Esse nome já esta em uso, por favor escolha outro");
                }

                await _unitOfWork._timeRepository.AddAsync(time);
                _unitOfWork.Save();

                return new SuccessfullCreateResponseModel(true, time.Id);
            }
            catch (Exception)
            {
                return new FailedResponseModel(false, "Erro ao criar novo time");
            }
        }

        public async Task<IBaseResponseModel> UpdateTime(TimeInputModel input, int id)
        {
            Time time = new Time { Nome = input.Nome };

            try
            {
                if (_unitOfWork._timeRepository.NameAlreadyExists(time.Nome))
                {
                    return new FailedResponseModel(false, "Nome já em uso, por favor escolha outro");
                }

                var timeStored = await _unitOfWork._timeRepository.GetByIdAsync(id);
                if (timeStored == null)
                {
                    return new FailedResponseModel(false, "Nenhum time com esse ID foi encontrado no sistema");
                }

                timeStored.Nome = input.Nome;

                _unitOfWork.Save();

                return new SucessfullResponseModel(true);
            }
            catch (Exception)
            {
                return new FailedResponseModel(false, "Erro ao atualizar time");
            }
        }

        public async Task<IBaseResponseModel> DeleteTime(int id)
        {
            try
            {
                var time = await _unitOfWork._timeRepository.GetByIdAsync(id);

                if (time == null)
                {
                    return new FailedResponseModel(false, "Nenhum time com esse ID foi encontrado no sistema");
                }

                if (await _unitOfWork._partidaRepository.TimeHavePlayed(id))
                {
                    return new FailedResponseModel(false, "Não é possível deletar o time, pois já participou de campeonatos");
                }

                _unitOfWork._timeRepository.Delete(time);
                _unitOfWork.Save();

                return new SucessfullResponseModel(true);
            }
            catch (Exception)
            {
                return new FailedResponseModel(false, "Erro ao deletar time");
            }
        }
    }
}

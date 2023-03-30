using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.Extensions.WebEncoders.Testing;

namespace FantasyGame.Models
{
    public interface IBaseResponseModel
    {
        bool OperationSucceeded();
        object GetResponse();
    }

    public class BaseResponseModel : IBaseResponseModel
    {
        protected bool Success { get; set; }
        protected IResponse? Response { get; set; }

        public bool OperationSucceeded()
        {
            return Success;
        }

        public virtual object GetResponse()
        {
            return Response == null ? "" : Response;
        }
    }

    public interface IResponse { }

    public class GetEntityResponseModel<TEntity> : BaseResponseModel, IBaseResponseModel
    {
        public TEntity Entity { get;}

        public GetEntityResponseModel(bool success, TEntity entity)
        {
            Success = success;
            if (entity == null)
            {
                throw new ArgumentNullException("Tentativa de inicializar entidade nula");
            }

            Entity = entity;
        }

        public override object GetResponse()
        {
            return Entity!;
        }
    }

    public class SucessfullResponseModel : BaseResponseModel, IBaseResponseModel
    {
        public SucessfullResponseModel(bool success) { Success = success; }
    }

    public class GetPagedResponse<T> : BaseResponseModel, IBaseResponseModel
    {
        public GetPagedResponse(bool success, int pagina, int tamanhoPagina, int qtdPagina, IList<T> itens)
        {
            Response = new PagedResponse<T>(pagina, tamanhoPagina, qtdPagina, itens);
            Success = success;
        }
    }

    public class PagedResponse<T> : IResponse
    {
        public int Pagina { get; set; }
        public int TamanhoPagina { get; set; }
        public int QtdPagina { get; set; }
        public IList<T> Itens { get; set; }

        public PagedResponse(int pagina, int tamanhoPagina, int qtdPagina, IList<T> itens)
        {
            Pagina = pagina;
            TamanhoPagina = tamanhoPagina;
            QtdPagina = qtdPagina;
            Itens = itens;
        }
    }

    public class SuccessfullCreateResponseModel : BaseResponseModel, IBaseResponseModel
    {
        public SuccessfullCreateResponseModel(bool success, int newId)
        {
            Success = success;
            Response = new SuccessfullCreateResponse() { NovoID = newId };
        }
    }

    public class SuccessfullCreateResponse : IResponse
    {
        public int NovoID { get; set; }
    }


    public class FailedResponseModel : BaseResponseModel, IBaseResponseModel
    {
        public FailedResponseModel(bool success, List<string> errors)
        {
            Success = success;
            Response = new FailedResponse(errors);
        }

        public FailedResponseModel(bool success, string error)
        {
            Success = success;
            Response = new FailedResponse(new List<string>() { error });
        }
    }

    public class FailedResponse : IResponse
    {
        public Error Errors { get; set; }
        public FailedResponse(List<string> errors)
        {
            Errors = new Error(errors);
        }

        public FailedResponse(string error)
        {
            Errors = new Error(error);
        }
    }

    //Classe util pro erro retornado ter o mesmo padrão do retornado pelas controllers quando falha validação do model de input
    //Dessa forma, os clientes da API nao precisam fazer dois tipos de validação diferentes buscando pela lista de erros
    public class Error
    {
        public IList<string> Errors { get; set; }
        public Error(IList<string> errors)
        {
            if (errors == null) { Errors = new List<string>(); }
            else Errors = errors;
        }

        public Error(string error)
        {
            Errors = new List<string>
            {
                error
            };
        }
    }
}
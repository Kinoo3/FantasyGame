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
}
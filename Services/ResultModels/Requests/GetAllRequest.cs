using Services.Contracts;

namespace Services.ResultModels.Requests
{
    public class GetAllRequest<T> : DecisionModel<T>
    {
        public GetAllRequest(T result, int type, string service, ILogService log) : base(result, type, service, log)
        {
        }
    }
}

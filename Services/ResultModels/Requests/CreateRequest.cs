using Services.Contracts;

namespace Services.ResultModels.Requests
{
    public class CreateRequest<T> : DecisionModel<T>
    {
        public CreateRequest(T result, int type, string service, ILogService log) : base(result, type, service, log)
        {
        }
    }
}

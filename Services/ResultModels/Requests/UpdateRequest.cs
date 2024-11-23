using Services.Contracts;

namespace Services.ResultModels.Requests
{
    public class UpdateRequest<T> : DecisionModel<T>
    {
        public UpdateRequest(T result, int type, string service, ILogService log) : base(result, type, service, log)
        {
        }
    }
}

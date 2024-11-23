using Services.Contracts;

namespace Services.ResultModels.Requests
{
    public class DeleteRequest<T> : DecisionModel<T>
    {
        public DeleteRequest(T result, int type, string service, ILogService log) : base(result, type,service, log)
        {
        }
    }
}

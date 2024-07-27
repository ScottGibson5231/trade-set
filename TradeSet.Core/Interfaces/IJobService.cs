namespace TradeSet.Core;

public interface IJobService
{
    Task<(bool success, Guid? jobId)> CreateJobAndNotifyWorkersAsync(Guid employerId, CreateJobRequest request);
}

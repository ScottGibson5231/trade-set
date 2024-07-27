using TradeSet.Core;
using TradeSet.Infrastructure;

namespace TradeSet.Services;

public class JobService : IJobService
{
    private readonly TradeSetDbContext _tradeSetDbContext;
    private readonly IWorkerService _workerService;
    public JobService(TradeSetDbContext tradeSetDbContext, IWorkerService workerService)
    {
        _tradeSetDbContext = tradeSetDbContext;
        _workerService = workerService;
    }

    public async Task<(bool success, Guid? jobId)> CreateJobAndNotifyWorkersAsync(Guid employerId, CreateJobRequest request)
    {
        try
        {
        var job = new Job()
        {
            Id = Guid.NewGuid(),
            JobType = request.JobType,
            HourlyRate = request.HourlyRate,
            Hours = request.Hours,
            StartDate = request.StartDate, 
            EndDate = request.EndDate,
        };

        await _tradeSetDbContext.Jobs.AddAsync(job);
        await _tradeSetDbContext.SaveChangesAsync();   

        //Now that job is created, we need to trigger the notification
        await _workerService.NotifyWorkersAboutJobPostingAsync(job);

        return (true, job.Id);
        }
        catch (Exception e)
        {
            return (false, null);
        }
    }
}

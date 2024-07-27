using TradeSet.Core;
using TradeSet.Infrastructure;

namespace TradeSet.Services;

public class JobService : IJobService
{
    private readonly TradeSetDbContext _tradeSetDbContext;
    public JobService()
    {

    }

    public async Task CreateJobAsync(Guid employerId, CreateJobRequest request)
    {
        var job = new Job()
        {
            JobType = request.JobType,
            HourlyRate = request.HourlyRate,
            Hours = request.Hours,
            StartDate = request.StartDate, 
            EndDate = request.EndDate,
        }
    }
}

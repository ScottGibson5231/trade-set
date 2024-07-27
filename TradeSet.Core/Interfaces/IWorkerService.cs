namespace TradeSet.Core;

public interface IWorkerService
{
    Task NotifyWorkersAboutJobPostingAsync(Job job);
}

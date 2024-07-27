namespace TradeSet.Core;

public class CreateJobRequest
{
    public JobType JobType {get;set;}
    public decimal HourlyRate {get;set;}
    public int Hours {get;set;}
    public DateTime StartDate {get;set;}
    public DateTime EndDate {get;set;}
}

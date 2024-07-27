namespace TradeSet.Core;

public class Job
{
    public Guid Id { get; set; }
    public Guid EmployerId { get; set; }
    public Employer Employer { get; set; }
    public JobStatus Status { get; set; } = JobStatus.Vacant; 
    public JobType JobType {get;set;}
    public decimal HourlyRate {get;set;}
    public int Hours {get;set;}
    public DateTime StartDate {get;set;}
    public DateTime EndDate {get;set;}
    public Guid WorkerId {get;set;}
    public Worker Worker{ get; set; }
}

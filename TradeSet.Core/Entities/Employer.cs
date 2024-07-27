namespace TradeSet.Core;

public class Employer : Account
{
    public string EmployerName { get; set; }
    public List<Job> Jobs {get;set;}
}

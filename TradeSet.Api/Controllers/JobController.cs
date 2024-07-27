using Microsoft.AspNetCore.Mvc;
using TradeSet.Core;


namespace TradeSet.Api;

[ApiController]
[Route("api/[controller]")]
public class JobController
{
    private readonly IJobService _jobService;
    private readonly IEmployerService _employerService;

    public JobController(IJobService jobService, IEmployerService employerService)
    {
        _jobService = jobService;
        _employerService = employerService;
    }

    [HttpPost]
    [Route("job")]
    public async Task<IActionResult> CreateJobAsync(CreateJobRequest request)
    {
        // TODO: check if employer exists (ID will come in from a token)
        //_employerService.GetEmployerById(Id);

        // TODO: create job
        // TODO: Notify workers that job is posted
        var response = await _jobService.CreateJobAndNotifyWorkersAsync(Guid.NewGuid() ,request);

        if(response.success)
        {
            return new OkObjectResult(response.jobId);
        }

        return new BadRequestObjectResult("Unable to create job");
    }
}

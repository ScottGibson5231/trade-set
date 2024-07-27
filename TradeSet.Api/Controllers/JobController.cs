using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TradeSet.Core;


namespace TradeSet.Api;

[ApiController]
[Route("[controller]")]
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
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateJobAsync(CreateJobRequest request)
    {
        // TODO: check if employer exists (ID will come in from a token)
        //_employerService.GetEmployerById(Id);

        // TODO: create job
        // TODO: Notify workers that job is posted
        try{
        var response = await _jobService.CreateJobAndNotifyWorkersAsync(request);

        if(response.Success){
            return Ok(response);
        }
        return BadRequest(response.Message);
        }
        catch(Exception e)
        {
            return StatusCode(500);
        }
    }
}

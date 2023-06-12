using Microsoft.AspNetCore.Mvc;
using tweetProcessor.Cache;
using tweetProcessor.Models;

namespace tweetProcessor.Controllers;

[Route("api/[controller]")]
[ApiController]
public class tweetProcessorController:ControllerBase
{
    
    private ICacheService _cacheService;

    public tweetProcessorController(ICacheService cacheService)
    {
        _cacheService = cacheService;
    }

    [HttpPost]
    [Route("populateTimeline")]
    public async Task<IActionResult> PopulateTimeline( ProcessorDTO processor)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            foreach (var follower in processor.followers)
            {
                var result = _cacheService.SetTimeline(follower, processor.tweet);
                // if (result)
                // {
                //     return Ok();
                // }

                // return Problem("Could not add tweet to follwers timelines");
                return Ok(result);

            }
        }
        catch (Exception ex)
        {
            
        }

        return Ok();


    }

    [HttpGet]
    [Route("populateTimeline")]
    public async Task<IActionResult> GetTimeline(string followeeId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result =  _cacheService.GetData(followeeId);
        return Ok(result);
    }
    
    
}
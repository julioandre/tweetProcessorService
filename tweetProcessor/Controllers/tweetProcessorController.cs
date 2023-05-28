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
    public async Task<IActionResult> PopulateTimeline([FromBody] IEnumerable<string> followers, Tweet tweet)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            foreach (var follower in followers)
            {
                var result = _cacheService.SetTimeline(follower, tweet);
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
    
    
}
using Microsoft.AspNetCore.Mvc;
using NewsAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class NewsController: ControllerBase {

    private readonly INewsService _newsService; 
    private readonly ILogger<ProfileController> _logger; 
    public NewsController(INewsService newsService, ILogger<ProfileController> logger)
    {
        _logger = logger; 
        _newsService = newsService; 
    }

    // Action method that is used for retrieving a users profile
    // A action method is returned with the user profile
    [HttpGet("/news")]
    public ActionResult<ResponseMessage<List<Article>>> GetMainNewsFeedRes(){
        ResponseMessage<List<MockArticle>> getMainNewsFeedRes = _newsService.GetMainNewsFeed();

        return Ok(getMainNewsFeedRes); 
    }
}
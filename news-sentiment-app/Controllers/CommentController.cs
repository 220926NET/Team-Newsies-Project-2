using Microsoft.AspNetCore.Mvc;



[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase
{
    private readonly ILogger<CommentController> _logger;

    private readonly ICommentService _commentService; 

    public CommentController(ILogger<CommentController> logger, ICommentService commentService)
    {
        _logger = logger;
        _commentService = commentService; 
    }

    // This controller action method takes in a comment and article ID
    // and passes it to comment services to be ran through googles 
    // sentiment api 
    [HttpPost("Comment")]
    public ActionResult<ResponseMessage<string>> Comment(string comment, int articleId)
    {
        _logger.LogInformation("a user access post action method post comment");
        ResponseMessage<string> postCommentRes = _commentService.AddCommentSentiment(comment,articleId);

        return Ok(postCommentRes); 
    }


    [HttpGet("{articleId}")]
    public ActionResult<ResponseMessage<Comment>> getArticleComments(int articleId){
        //TODO: This endpoint will return article comments based on a given article Id to display to the user 
        _logger.LogInformation("a user access get action method get article comments");
        return Ok(_commentService.GetArticleComments(articleId)); 

    }
}

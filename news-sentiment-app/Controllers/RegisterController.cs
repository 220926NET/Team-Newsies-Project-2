using Microsoft.AspNetCore.Mvc;



[ApiController]
[Route("api/[controller]")]
public class RegisterController : ControllerBase
{
    private readonly ILogger<LoginController> _logger;

   
    public RegisterController(ILogger<LoginController> logger)
    {
        _logger = logger;
    }

   [HttpPost]
   public ActionResult<ResponseMessage<string>> Register([FromBody]LoginDto loginDto){
   
    ResponseMessage<string> registerResponse = new ResponseMessage<string>();
    registerResponse.Success = true;
    registerResponse.Message = "You have successfully registered!"; 

    return Ok(registerResponse); 

   }

}

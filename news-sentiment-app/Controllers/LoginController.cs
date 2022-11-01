using Microsoft.AspNetCore.Mvc;



[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly ILogger<LoginController> _logger;

    private readonly ILoginService _loginService; 
    public LoginController(ILogger<LoginController> logger, ILoginService loginService)
    {
        _logger = logger;
        _loginService = loginService; 
    }

   [HttpPost]
   public ActionResult<ResponseMessage<string>> login(LoginDto loginDto){

    //TODO: Add validation for pa

    ResponseMessage<string> loginResponse = _loginService.Login(loginDto); 

    return Ok(loginResponse); 

   }
}

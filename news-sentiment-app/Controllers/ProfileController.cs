using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProfileController: ControllerBase {

    private readonly IProfileService _iprofileService; 
    private readonly ILogger<ProfileController> _logger; 
    public ProfileController(IProfileService profileService, ILogger<ProfileController> logger)
    {
        _logger = logger; 
        _iprofileService = profileService; 
    }

    // Action method that is used for retrieving a users profile
    // A action method is returned with the user profile
    [HttpGet("/profile")]
    public ActionResult<ResponseMessage<Profile>> getProfile(){

        _logger.LogInformation("user accessed profile get profile action method"); 
        return Ok(_iprofileService.getProfile());
    }
}
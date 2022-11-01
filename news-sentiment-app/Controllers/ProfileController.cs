using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ProfileController: ControllerBase {

    private readonly IProfileService _iprofileService; 
    public ProfileController(IProfileService profileService)
    {
        _iprofileService = profileService; 
    }


    // Action method that is used for retrieving a users profile
    // A action method is returned with the user profile
    [HttpGet("/profile")]
    public ActionResult<ResponseMessage<Profile>> getProfile(){

        return Ok(_iprofileService.getProfile());
    }
}
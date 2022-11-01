using System.Security.Claims; 
using Microsoft.IdentityModel.Tokens; 
using System.IdentityModel.Tokens; 
using System.IdentityModel.Tokens.Jwt; 
using System.Text;
public class LoginService : ILoginService{

    public LoginService()
    {
        
    }

    // This method takes in a loginDto which contians a username and password
    // the username and password is verified by checking the database
    // if the user exists return a token, else, 
    // set the responseMessage.success to false and message = "unable to login user, password or username is incorrect"
    public ResponseMessage<string> Login(LoginDto login){
        ResponseMessage<string> loginResponse = new ResponseMessage<string>();

        // create a token 
        string token = CreateToken("1", "userName1");
        
        // This sets the ResponseMessage object that is sent back to the user
        loginResponse.data = token;
        loginResponse.Success = true;
        loginResponse.Message = "Successfully logged in!"; 

        return loginResponse; 

     }


    // This method creates a jwt token that will be sent back to the user once he has logged in
    private string CreateToken(string id, string userName){
            List<Claim> claims = new List<Claim>{
                new Claim(ClaimTypes.Sid, id),
                new Claim(ClaimTypes.Name, userName)
            }; 

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MyTopSecretToken123"));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature); 

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            }; 

            JwtSecurityTokenHandler tokenHandler  = new JwtSecurityTokenHandler(); 
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor); 

            return tokenHandler.WriteToken(token); 
        }
    


}
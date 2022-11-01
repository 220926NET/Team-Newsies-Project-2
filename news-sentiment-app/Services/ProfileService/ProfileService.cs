

public class ProfileService : IProfileService {

// TODO: define what should be inside our user profile class and what database should return 

    public ResponseMessage<Profile> getProfile(){
        ResponseMessage<Profile> getProfileRes = new ResponseMessage<Profile>();
        
        Profile userProfile = new Profile(){
            Name = "John",
            Comments = new List<Comment>(){
                new Comment(){ArticleName = "Elon musk .. ", Sentiment = -.3, Content ="I hate this article", ArticleId = 100},
                new Comment(){ArticleName = "BMW & Their Robots Are Going To Take Your Forklift Cert Away. Good Luck Having A Date Again, Ever", Sentiment = 1, Content ="Wow this is awesome", ArticleId = 200},
                new Comment(){ArticleName = "Emerson sells part of business, says it would consider leaving St. Louis - St. Louis Post-Dispatch ", Sentiment = .3, Content ="hmm idk what I think", ArticleId = 300}
            }
        }; 


        // Sets our response message data to user profile, our success flag and our message
        getProfileRes.data = userProfile; 
        getProfileRes.Success = true;
        getProfileRes.Message = "Successfully retrieved user messages!"; 
       
    
       return getProfileRes; 


    }
}
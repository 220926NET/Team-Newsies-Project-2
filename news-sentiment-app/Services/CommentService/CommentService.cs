using Google.Cloud.Language.V1;

public class CommentService : ICommentService {


    // Method used to retrieve a sentiment from gooogle api service
    // In order to use this api user must first setup a Google_Application_Credentials enviroment variable
    // Please read here https://cloud.google.com/docs/authentication/application-default-credentials
    // Else an error is thrown stating that user does not have access 
    public ResponseMessage<string> AddCommentSentiment(string comment, int articleId){
        ResponseMessage<string> addCommentSentimentRes = new ResponseMessage<string>();

        LanguageServiceClient client = LanguageServiceClient.Create();
        Document document = Document.FromPlainText($"{comment}");
        AnalyzeSentimentResponse response = client.AnalyzeSentiment(document);

        float commentSentiment  = response.DocumentSentiment.Score; 

        addCommentSentimentRes.Message = commentSentiment.ToString(); 
        addCommentSentimentRes.Success = true; 

        //TODO: pass comment and sentiment to database for persistence 


        return addCommentSentimentRes; 

    }

    // Method is for returning article comments so they may displayed to the user once they click on a article to view
    // returns a list of comments
    // Comments 
    public ResponseMessage<List<Comment>> GetArticleComments(int articleId) {
        // This represents a comment that is relevant to our news article returned from our database
        List<Comment> comments = new List<Comment>(){
            new Comment("emmanuel", "Thiss was an awesome read", 1),
            new Comment("george", "I hated this ", -.8), 
            new Comment("daniel", "Wow really insightful", .5)
        }; 
        
        ResponseMessage<List<Comment>> getArticleCommentRes = new ResponseMessage<List<Comment>>();
        getArticleCommentRes.data = comments; 
        getArticleCommentRes.Success = true;
        getArticleCommentRes.Message = "successfully retrieved comments";

        return getArticleCommentRes;  
    }
}
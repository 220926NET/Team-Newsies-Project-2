

public interface ICommentService {

     ResponseMessage<string> AddCommentSentiment(string comment, int articleId);

     ResponseMessage<List<Comment>> GetArticleComments(int articleId); 
}
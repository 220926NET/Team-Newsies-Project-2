using NewsAPI.Models;
public interface INewsService {

    ResponseMessage<List<MockArticle>> GetMainNewsFeed();
}
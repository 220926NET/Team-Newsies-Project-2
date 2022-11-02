using NewsAPI.Models;
public interface INewsService {

    ResponseMessage<List<Article>> GetMainNewsFeed();
}
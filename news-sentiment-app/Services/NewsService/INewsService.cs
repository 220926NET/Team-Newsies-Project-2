using NewsAPI.Models;
public interface INewsService
{

    Task<ResponseMessage<List<MockArticle>>> GetMainNewsFeed();
}
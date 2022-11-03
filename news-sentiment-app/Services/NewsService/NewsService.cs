using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;

using AutoMapper;
public class NewsService : INewsService
{

    private readonly Repository _repo;


    public NewsService(Repository repo)
    {
        _repo = repo;

    }
    public async Task<ResponseMessage<List<MockArticle>>> GetMainNewsFeed()
    {
        ResponseMessage<List<MockArticle>> getNewsResponse = new ResponseMessage<List<MockArticle>>();
        getNewsResponse = await _repo.GetNewsFeed();
        return getNewsResponse;

    }

}
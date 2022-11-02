using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using System;
public class NewsService : INewsService {

    

    public ResponseMessage<List<Article>> GetMainNewsFeed(){

        ResponseMessage<string> getMainNewsFeedRes = new ResponseMessage<string>();
        var newsApiClient = new NewsApiClient("3987567222d641f9a7cfa053f76db36b");


        ResponseMessage<List<Article>> newsArticleRes = new ResponseMessage<List<Article>>();
        TopHeadlinesRequest headlinesRequest = new TopHeadlinesRequest(){
            // IF category is not specified it returns all categories
            // Category = Categories.Science,
            Language = Languages.EN,
            Country = Countries.US,
            //sets the amount of articles we want to see
            PageSize = 10 
        };

        var articlesResponse  = newsApiClient.GetTopHeadlines(headlinesRequest);

            newsArticleRes.data = articlesResponse.Articles;

            if(articlesResponse.Status == Statuses.Ok){
                newsArticleRes.Success = true; 
                newsArticleRes.Message = "Retrieved all news"; 
            } else {
                // gets the error message 
                newsArticleRes.Message = articlesResponse.Error.Message;
            }


          foreach(Article article in articlesResponse.Articles){
            //TODO: Add each url into a database 
            // if a url already exists then dont add article to db
            // return article and article Id 
            Console.WriteLine(article.Url);
          }

        Task.Delay(5000);

        //TODO return all articles that have a datetime of today

        return newsArticleRes; 

    }

}
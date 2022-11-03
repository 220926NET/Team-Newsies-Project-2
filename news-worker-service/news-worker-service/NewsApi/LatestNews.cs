using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using System;
using System.Security.Cryptography;
using System.Text;
using System;

// this class retrieves the latest news from news api on a periodic basis 

public class LatestNews
{

    private readonly Repository _repo;


    public LatestNews(Repository repo)
    {
        _repo = repo;

    }



    public void SetLatestNewsInDb()
    {
        var newsApiClient = new NewsApiClient("3987567222d641f9a7cfa053f76db36b");
        TopHeadlinesRequest headlinesRequest = new TopHeadlinesRequest()
        {
            // IF category is not specified it returns all categories
            // Category = Categories.Science,
            Language = Languages.EN,
            Country = Countries.US,
            //sets the amount of articles we want to see
            PageSize = 50
        };

        var articlesResponse = newsApiClient.GetTopHeadlines(headlinesRequest);

        List<MockArticle> mockArticles = new List<MockArticle>();

        foreach (Article article in articlesResponse.Articles)
        {
            if (string.IsNullOrEmpty(article.Author) || article.Author.Length > 255)
            {
                article.Author = "Author name unavailable";
            }

            byte[] tmpSource = ASCIIEncoding.ASCII.GetBytes(article.Url);
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(tmpSource);
            var hashString = ByteArrayToString(hash);
            Console.WriteLine("hash string is " + hashString);

            MockArticle mockArticle = new MockArticle
            {
                Id = hashString,
                Author = article.Author,
                Title = article.Title,
                Description = article.Description,
                UrlToImage = article.UrlToImage,
                Url = article.Url,
                PublishedAt = article.PublishedAt.ToString()!,

            };

            //todo if article already exists dont add to database

            //if article already exists dont add it to list of articles 
            if (_repo.NewsHasBeenAdded(hashString))
            {
                Console.WriteLine("that file has already been added");
            }
            else
            {
                mockArticles.Add(mockArticle);
            }

        }


        _repo.AddNews(mockArticles);




    }

    static string ByteArrayToString(byte[] arrInput)
    {
        int i;
        StringBuilder sOutput = new StringBuilder(arrInput.Length);
        for (i = 0; i < arrInput.Length; i++)
        {
            sOutput.Append(arrInput[i].ToString("X2"));
        }
        return sOutput.ToString();
    }





}
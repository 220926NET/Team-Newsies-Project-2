

public class MockArticle
{
    public int Id { get; set; }

    public string Author { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }

    public string UrlToImage { get; set; }

    public string Url { get; set; }

    public string PublishedAt { get; set; }

    public double Sentiment { get; set; }

    public MockArticle()
    {

    }
    public MockArticle(int id, string title, string author, string description, string urlToImage, string url, string publishedAt, double sentiment)
    {
        Id = id;
        Title = title;
        Author = author;
        Description = description;
        UrlToImage = urlToImage;
        Url = url;
        PublishedAt = publishedAt;
        Sentiment = sentiment;
    }


}
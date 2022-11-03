using Microsoft.Data.SqlClient;
public class Repository
{

    private SqlConnection _connection;
    private string _connectionString = Secrets.GetOdbcStr();

    public Repository()
    {
        _connection = new SqlConnection(_connectionString);
    }

    public async Task<ResponseMessage<string>> AddNews(List<MockArticle> articles)
    {
        ResponseMessage<string> addNewsRes = new ResponseMessage<string>();

        try
        {
            Console.WriteLine("inside inserting statement");
            Console.WriteLine("article count is " + articles.Count());
            _connection.Open();

            for (int i = 0; i < articles.Count; i++)
            {
                MockArticle article = articles[i];
                //exec insert_into_articles "emmanuiel", "title", "description", "url", "urltoiamge", "2022-05-09", 1
                SqlCommand cmd = new SqlCommand("exec insert_into_articles @author, @title, @description, @url, @urlToImage, @publishedAt, @sentiment", _connection);
                cmd.Parameters.AddWithValue("@author", article.Author);
                cmd.Parameters.AddWithValue("@title", article.Title);
                cmd.Parameters.AddWithValue("@description", article.Description);
                cmd.Parameters.AddWithValue("@url", article.Url);
                cmd.Parameters.AddWithValue("@urlToImage", article.UrlToImage);
                cmd.Parameters.AddWithValue("@publishedAt", article.PublishedAt);
                cmd.Parameters.AddWithValue("@sentiment", article.Sentiment);
                int res = await cmd.ExecuteNonQueryAsync();
                Console.WriteLine("res is " + res);
            }

            _connection.Close();
            _connection.Open();

            addNewsRes.Success = true;
            addNewsRes.Message = "Successfully added news into database";
        }
        catch (SqlException e)
        {

            Console.WriteLine(e.Message);
            addNewsRes.Message = "There was an issues adding news into database.";
            addNewsRes.Success = false;
        }
        finally
        {
            _connection.Close();
        }


        return addNewsRes;
    }
    public async Task<ResponseMessage<List<MockArticle>>> GetNewsFeed()
    {
        ResponseMessage<List<MockArticle>> addNewsRes = new ResponseMessage<List<MockArticle>>();
        List<MockArticle> articleList = new List<MockArticle>();

        try
        {

            _connection.Open();

            SqlCommand cmd = new SqlCommand("exec get_news_feed", _connection);
            SqlDataReader reader = await cmd.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString()!);
                    string title = reader["title"].ToString()!;
                    string author = reader["author"].ToString()!;
                    string description = reader["description"].ToString()!;
                    string urlToImage = reader["urlToImage"].ToString()!;
                    string url = reader["url"].ToString()!;
                    string publishedAt = reader["publishedAt"].ToString()!;
                    double sentiment = double.Parse(reader["sentiment"].ToString()!);


                    articleList.Add(new MockArticle(id, title, author, description, urlToImage, url, publishedAt, sentiment));

                }
            }

            _connection.Close();
            _connection.Open();

            addNewsRes.data = articleList;
            addNewsRes.Success = true;
            addNewsRes.Message = "Successfully retrieved articles";
        }
        catch (SqlException e)
        {

            Console.WriteLine(e);
            addNewsRes.Message = "There was an issues retrieving articles try again later.";
            addNewsRes.Success = false;
        }
        finally
        {
            _connection.Close();
        }


        return addNewsRes;
    }
}
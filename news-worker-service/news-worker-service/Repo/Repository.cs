using Microsoft.Data.SqlClient;
public class Repository
{

    private SqlConnection _connection;
    private string _connectionString = "Server=tcp:220926netp2dbs.database.windows.net,1433;Initial Catalog=newsDB;Persist Security Info=False;User ID=newscollector;Password=a11TheNew$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

    public Repository()
    {
        _connection = new SqlConnection(_connectionString);
    }

    public void AddNews(List<MockArticle> articles)
    {
        ResponseMessage<string> addNewsRes = new ResponseMessage<string>();

        try
        {
            Console.WriteLine("inside inserting statement");
            Console.WriteLine("article count is " + articles.Count());
            _connection.Open();

            for (int i = 0; i < articles.Count; i++)
            {
                Console.WriteLine("inside for loop");
                MockArticle article = articles[i];
                //exec insert_into_articles "emmanuiel", "title", "description", "url", "urltoiamge", "2022-05-09", 1
                SqlCommand cmd = new SqlCommand("exec insert_into_articles @author, @title, @description, @url, @urlToImage, @publishedAt, @sentiment, @urlId", _connection);
                cmd.Parameters.AddWithValue("@author", article.Author);
                cmd.Parameters.AddWithValue("@title", article.Title);
                cmd.Parameters.AddWithValue("@description", article.Description);
                cmd.Parameters.AddWithValue("@url", article.Url);
                cmd.Parameters.AddWithValue("@urlToImage", article.UrlToImage);
                cmd.Parameters.AddWithValue("@publishedAt", article.PublishedAt);
                cmd.Parameters.AddWithValue("@sentiment", article.Sentiment);
                cmd.Parameters.AddWithValue("@urlId", article.Id);
                cmd.ExecuteNonQuery();
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
    }

    public bool NewsHasBeenAdded(string urlId)
    {
        ResponseMessage<string> addNewsRes = new ResponseMessage<string>();

        try
        {
            _connection.Open();
            //exec insert_into_articles "emmanuiel", "title", "description", "url", "urltoiamge", "2022-05-09", 1
            SqlCommand cmd = new SqlCommand("exec article_exists @urlId", _connection);
            cmd.Parameters.AddWithValue("@urlId", urlId);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                return true;
            }

            _connection.Close();
            _connection.Open();


        }
        catch (SqlException e)
        {

            Console.WriteLine(e.Message);

        }
        finally
        {
            _connection.Close();
        }

        return false;
    }
}
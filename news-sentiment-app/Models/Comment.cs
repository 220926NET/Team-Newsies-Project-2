

// This class represents a comment
// Comment contains string content that represents the actual comment
// Sentiment represents a value from -1 to 1 that represent the content sentiment 
public class Comment {
    public string Content {get; set;} = string.Empty; 

    public string ArticleName {get; set;} = string.Empty; 
    public int  ArticleId {get; set;} = 0; 

    public Double Sentiment {get; set;}

    public Comment()
    {
        
    }
    public Comment(string comment, Double sentiment)
    {
        Content = comment;
        Sentiment = Sentiment; 
    }
    
}
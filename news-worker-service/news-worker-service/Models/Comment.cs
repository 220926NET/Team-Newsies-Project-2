

// This class represents a comment
// Comment contains string content that represents the actual comment
// Sentiment represents a value from -1 to 1 that represent the content sentiment 
public class Comment {

    public string Name {get; set;} = string.Empty; 
    public string Content {get; set;} = string.Empty; 

    public Double Sentiment {get; set;}

    
    public Comment(string name, string comment, Double sentiment)
    {
        Name = name;
        Content = comment;
        Sentiment = Sentiment; 
    }
    
}
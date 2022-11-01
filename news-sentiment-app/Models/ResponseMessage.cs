

public class ResponseMessage<T> {
    public T? data {get; set;}

    public bool Success {get; set;} = false; 

    public string? Message {get; set;}

}
using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using System;
public class NewsService : INewsService {

    // Mocked data to send to the front end
    // awaiting implementation 
    private readonly List<MockArticle> MockArticleData = new List<MockArticle>(){
        new MockArticle(1,"Boeing Lays Out Plan to Rebound From 737 MAX, Other Problems", "Andrew Tangel, Doug Cameron", "Aerospace company says it is focused on boosting jetliner production to pay down debt, with dividends or buybacks returning as soon as 2026",
         "https://images.wsj.net/im-656950/social", "https://www.wsj.com/articles/boeing-lays-out-plan-to-rebound-from-737-max-other-problems-11667414350",
         "2022-11-02T18:39:00Z", .3), 
         new MockArticle(2,"Fed Approves Fourth 0.75-Point Rate Rise, Hints at Smaller Hikes", "Nick Timiraos", "Officials signal a possible slowdown in the pace of rate rises by acknowledging how increases influence the economy with a lag",
         "https://images.wsj.net/im-655758/social", "https://www.wsj.com/articles/fed-approves-fourth-0-75-point-rate-rise-hints-at-smaller-hikes-11667412242",
         "2022-11-02T18:21:00", 1), 
         new MockArticle(3,"White Suburban Women Swing Right?", "www.wsj.com", "New WSJ poll shows key group of midterm voters favors the GOP by 15 percentage points",
         "https://images.wsj.net/im-656693/social", "https://www.wsj.com/articles/white-suburban-women-swing-toward-backing-republicans-for-congress-11667381402",
         "2022-11-02T14:00:04Z", -1), 
         new MockArticle(4,"Jony Ive on Life After Apple", "Elisa Lipsky-Karasz", "The mastermind behind Apple’s most iconic products reveals how his design philosophy guides collaborations at his creative collective, LoveFrom.",
         "https://images.wsj.net/im-650756/social", "https://www.wsj.com/articles/jony-ive-apple-design-interview-profile-lovefrom-11666733971",
         "2022-11-02T12:35:08Z", -.3), 
    }; 
    public ResponseMessage<List<MockArticle>> GetMainNewsFeed(){

        ResponseMessage<List<MockArticle>> getMainNewsFeedRes = new ResponseMessage<List<MockArticle>>();
        
        getMainNewsFeedRes.data = MockArticleData; 
        getMainNewsFeedRes.Success = true; 
        getMainNewsFeedRes.Message = "Breaking news feed"; 
        //TODO return all articles that have a datetime of today

        return getMainNewsFeedRes; 

    }

}
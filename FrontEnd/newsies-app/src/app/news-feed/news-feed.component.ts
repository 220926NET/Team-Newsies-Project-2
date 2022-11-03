import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { MockArticle } from 'src/models/MockArticle';
import ResponseMessage from 'src/models/ResponseMessage';

@Component({
  selector: 'app-news-feed',
  templateUrl: './news-feed.component.html',
  styleUrls: ['./news-feed.component.css']
})
export class NewsFeedComponent implements OnInit {

  newsUrl : string = "https://localhost:7062/news"; 

  constructor(private _httpClient : HttpClient) { }

  mockArticles : MockArticle[] = []; 

  viewingComments : boolean = false; 

  ngOnInit(): void {
    this._httpClient.get<ResponseMessage>(this.newsUrl).subscribe(responseData => {
      this.mockArticles = responseData.data; 
      console.log(responseData); 
    })

  }

  

  
}

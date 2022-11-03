import { Component, OnInit } from '@angular/core';
import { Input } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { MockArticle } from 'src/models/MockArticle';
import ResponseMessage from 'src/models/ResponseMessage';
import Comment from 'src/models/Comment';
@Component({
  selector: 'app-news-container',
  templateUrl: './news-container.component.html',
  styleUrls: ['./news-container.component.css']
})
export class NewsContainerComponent implements OnInit {

  getCommentsUrl :string = "https://localhost:7062/api/Comment/";

  //creates an array of comments to load onto the modal 
  
  articleComments : Comment[] = []; 

  // when set to false modal is not open
  // when users presses on html button
  // model opens and a get request is sent to retrieve 
  // the articles comments 

  viewComments :boolean = false; 

  @Input() article : MockArticle = {
    id : 0,
    description: "",
    author: "",
    title : "",
    urlToImage : "",
    url : "",
    sentiment: 1,
    publishedAt: ""
  }; 

  constructor(private _httpClient : HttpClient) { }

  ngOnInit(): void {
  }

  closeModal(){
    this.viewComments = false;
  }
  
  getComments(id : number){
    this._httpClient.get<ResponseMessage>(this.getCommentsUrl + id.toString()).subscribe(responseData => {
    
      this.articleComments = responseData.data;
    })
    this.viewComments = true;
  }

  
 
 
}

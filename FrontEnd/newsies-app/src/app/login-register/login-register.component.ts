import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms'
import {HttpClient} from '@angular/common/http'
import {map} from 'rxjs/operators'
import Login from '../../models/Login'
import ResponseMessage from 'src/models/ResponseMessage';


@Component({
  selector: 'app-login-register',
  templateUrl: './login-register.component.html',
  styleUrls: ['./login-register.component.css']
})
export class LoginRegisterComponent implements OnInit {
  submitBtnIsDisabled :boolean = true; 

  postRegisterUrl:string = "https://localhost:7062/api/Register"; 

  postLoginUrl :string = "https://localhost:7062/api/Login";

  isRegistering : boolean = false; 

  gotResponse : boolean = false; 

  loginInfo : Login  = {
    userName: "",
    password: ""
  };


  response : ResponseMessage = {
    data : "",
    success : false,
    message : ""
  }; 

  
  constructor(private _httpClient : HttpClient) { }

  ngOnInit(): void {
  }

  

  onSubmit(form: NgForm){
    // register or login 
    this.loginInfo.userName = form.controls["username"].value;
    this.loginInfo.password = form.controls["password"].value;
    
    if(this.isRegistering){
      console.log("registering");
         this.postRegister(this.loginInfo);
     
    }else {
      console.log("logging in");
      this.postLogin(this.loginInfo)
    }

    // if succesfully logged in set token in storage

    
  }
  postLogin(login: Login){
    this._httpClient.post<ResponseMessage>(this.postLoginUrl, login).subscribe(responseData => {
      this.response = responseData;
      this.gotResponse = true; 
      console.log("token is " + responseData.data);
      return responseData; 
    });
  }

  postRegister(register : Login){
     this._httpClient.post<ResponseMessage>(this.postRegisterUrl, register).subscribe(responseData  => {
      this.response = responseData; 
      this.gotResponse = true; 
      return responseData; 
    });
    
  }
  
  setIsRegistering(){
    this.gotResponse = false;
    this.isRegistering = !this.isRegistering; 
  }
}

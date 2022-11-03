import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import { AppComponent } from './app.component';
import { LoginRegisterComponent } from './login-register/login-register.component';
import { Routes, RouterModule} from '@angular/router';
import { NewsFeedComponent } from './news-feed/news-feed.component';
import { NewsContainerComponent } from './news-feed/news-container/news-container.component';
import { HeaderComponent } from './header/header.component';
import { ProfileComponent } from './profile/profile.component';
import { CommentModalComponent } from './comment-modal/comment-modal.component';

//contains array of routes 
const appRoutes : Routes = [
  {path: '', component: LoginRegisterComponent},
  {path:'news', component: NewsFeedComponent}
]; 


@NgModule({
  declarations: [
    AppComponent,
    LoginRegisterComponent,
    NewsFeedComponent,
    NewsContainerComponent,
    HeaderComponent,
    ProfileComponent,
    CommentModalComponent
  ],
  imports: [
    HttpClientModule,
    FormsModule,
    BrowserModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

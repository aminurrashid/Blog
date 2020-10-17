import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.css']
})
export class PostListComponent implements OnInit {
  public posts: PostView[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<PaginationApiResponse>(baseUrl + 'api/post').subscribe(result => {
      //this.posts = result.data;
      this.posts = [];
      result.data.forEach(element => {
        var postView: PostView = new PostView();
        postView.content = element.content;
        postView.createdAt = element.createdAt;
        postView.user = element.user.name;
        postView.otherInfo = (element.comments ? element.comments.length : 0) + " comment(s)";
        postView.isPost = true;
        this.posts.push(postView);

        element.comments.forEach(element => {
          var postView: PostView= new PostView();
          postView.content = element.content;
          postView.createdAt = element.createdAt;
          postView.user = element.user.name;
          postView.otherInfo = "";
          postView.isPost = false;
          this.posts.push(postView);
        });
      });
    }, error => console.error(error));
  }

  ngOnInit() {
  }

}

interface Meta {
  offset: number;
  limit: number;
  total: number;
}

interface PaginationApiResponse {
  data: any;
  meta: Meta;
}

class PostView {
  isPost: boolean;
  content: string;
  user: string;
  createdAt: Date;
  otherInfo: string;
}

interface Post {
  id: number;
  content: string;
  createdAt: Date;
  user: User;
  comments: Comment[]
}

interface User {
  id: number;
  name: string;
}

interface Comment {
  id: number;
  content: string;
  createdAt: Date;
  user: User;
}

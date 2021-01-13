import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({ //Decorator - a way of giving a normal class extra abilities
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Lalitas Dating Application';  //Class property - interpolation on HTML '{{user | json}}' 

  //Typescript gives us type safety unless using 'any'
  users: any;

  //Construct the app component then get the HttpClient
  //Dependancy Injection
  constructor(private http: HttpClient) { } //Asynchronous Request

  ngOnInit() {
    this.getUsers(); //Calling the getUsers methods
  }

  getUsers() {
    this.http.get('https://localhost:5001/api/users').subscribe(response => { //Using a HTTP request get service - a URL
      this.users = response; //Response is going to contain the users from the API server
    }, error => {
      console.log(error);  //In the case of an error - throw the error to the console
    })
  }
}


/* -- NOTES

Use 'this' to use any property within the class
'?' these things are optional, do not need to provide these e.g. 'header?'
Response body means the data is available
.subscribe will give what return data or a error if the request is invalid
CORS - Cross-origin resource sharing 

-- */


import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from './_models/user';
import { AccountService } from './_services/account.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'The Dating app';
  users: any;

  constructor(private accountService: AccountService) { }

  ngOnInit() {
    this.setCurrentUser();
  }
s
  setCurrentUser() {
    const user: User = JSON.parse(localStorage.getItem('user'));
    this.accountService.setCurrentUser(user)
  }
}

/* -- NOTES

Use 'this' to use any property within the class
'?' these things are optional, do not need to provide these e.g. 'header?'
Response body means the data is available
.subscribe will give what return data or a error if the request is invalid
CORS - Cross-origin resource sharing

-- */


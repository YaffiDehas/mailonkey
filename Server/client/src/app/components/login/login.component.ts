import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/user.service';
import { User } from 'src/Model/user';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

  // user: User = new User();
  // constructor(private UserService: UserService) { this.user = new User() }
  ngOnInit() {
   
  }
  // onlogin() {
  //   this.UserService.login(this.user.mail, this.user.password).subscribe(state => {
  //     this.user = state
  //   });
  // }

}


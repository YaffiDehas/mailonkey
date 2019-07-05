import { Component, OnInit } from '@angular/core';
import { User } from 'src/Model/user';
import { UserService } from 'src/app/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-mail-login',
  templateUrl: './mail-login.component.html',
  styleUrls: ['./mail-login.component.scss']
})
export class MailLoginComponent implements OnInit {

  user: User = new User();
  constructor(private UserService: UserService, private router: Router) { this.user = new User() }
  ngOnInit() {
    
  } 
  onlogin() {
    this.UserService.login(this.user.mail, this.user.password).subscribe((res: any) => {
      this.user = res;
      this.UserService.currentUser = this.user;
      
    },
      err => {
      this.router.navigate(['/register']);
      }
    );
  }
}


import { Component, OnInit } from '@angular/core';
import { User } from 'src/Model/user';
import { UserService } from 'src/app/user.service';

@Component({
  selector: 'app-preview-details',
  templateUrl: './preview-details.component.html',
  styleUrls: ['./preview-details.component.css']
})
export class PreviewDetailsComponent implements OnInit {

  currentUser:User;
  user:User;
  canVisible:boolean;
  constructor(private userService: UserService ) {this.canVisible=false; }

  ngOnInit() {
     this.user = this.userService.currentUser;
  }
  openPerferncesList(kindPerference:any){
    this.userService.currentUser.preference=kindPerference;
    this.canVisible=true;
}
}

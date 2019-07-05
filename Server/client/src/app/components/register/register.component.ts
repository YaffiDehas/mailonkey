import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserService } from 'src/app/user.service';
import { User } from 'src/Model/user';
import {Router} from "@angular/router"
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
user:User=new User();
  constructor(private userService:UserService,private router: Router) { }

  ngOnInit() {
  }
  onRegister(taskform:NgForm){
  this.userService.Register(this.user).subscribe(res=>{
    this.userService.currentUser=this.user;
    this.router.navigate(['/preview-details'])}
    ,err=>
    console.log("not succedded"));

  }
}

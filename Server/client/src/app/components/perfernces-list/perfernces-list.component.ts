import { Component, OnInit} from '@angular/core';
import{contact} from 'src/Model/contact';
import { UserService } from 'src/app/user.service';
import {User} from 'src/Model/user';
import { NgForm, NgModel } from '@angular/forms';

@Component({
  selector: 'app-perfernces-list',
  templateUrl: './perfernces-list.component.html',
  styleUrls: ['./perfernces-list.component.css']
})
export class PerferncesListComponent implements OnInit {
  user:User;
  input1:string;
  constructor(private userService:UserService) {
    this.userService.currentUser.contact_list=[];
    this.user=userService.currentUser}

  ngOnInit() {
    
  }
   saveData(){
     this.userService.Update(this.userService.currentUser).subscribe(res=>console.log("succeded"));
   }
   addInputEmail(){
   
    this.userService.currentUser.contact_list.push(this.input1);
    this.input1="";
   }
  
}

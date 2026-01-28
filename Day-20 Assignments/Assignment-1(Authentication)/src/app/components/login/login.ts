import { Component } from '@angular/core';
import { inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  router=inject(Router)
  userObj: any = {
 EmailId:'',
 Password:''
 }; 
 onLogin() {
 if (this.userObj.EmailId == "admin" && this.userObj.Password ==
"1234") {
 alert("login Success");
 localStorage.setItem('loginUser', this.userObj.EmailId)
 this.router.navigateByUrl('add-emp')
 } else {
 alert('Wrong Credentials')
 }
 } 


}

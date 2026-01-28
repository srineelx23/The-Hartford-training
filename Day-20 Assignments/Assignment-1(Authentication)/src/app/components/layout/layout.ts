import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router,RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-layout',
  imports: [RouterOutlet, RouterLink, FormsModule],
  templateUrl: './layout.html',
  styleUrl: './layout.css',
})
export class Layout {
  router=inject(Router)

  loggedUserData:any;
  constructor(){
    this.loggedUserData=localStorage.getItem('loginUser');
    if(this.loggedUserData==null){
      this.router.navigateByUrl('login');
    }
    console.log(this.loggedUserData);
  }

  logOff(){
    localStorage.removeItem('loginUser');
    this.router.navigateByUrl('login');
  }
}

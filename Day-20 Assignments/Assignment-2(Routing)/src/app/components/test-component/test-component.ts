import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-test-component',
  imports: [],
  templateUrl: './test-component.html',
  styleUrl: './test-component.css',
})
export class TestComponent {
  constructor(private router: Router) {}

goToHome(){
  console.log("home called")
  this.router.navigate(['/home']);
}
}

import { Component, effect, signal } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-home-component',
  imports: [RouterModule],
  templateUrl: './home-component.html',
  styleUrl: './home-component.css',
})
export class HomeComponent {
  prodData = [
{id:1, name:'Laptop', price:45000},
{id:2, name:'Mobile', price:25000},
{id:3, name:'Tablet', price:15000},
{id:4, name:'Smart Watch', price:8000},
{id:5, name:'Wireless Earbuds', price:6000}
];

product = signal({ id: 999, name: 'Computer', price: 70000 });


}

import { Component } from '@angular/core';
import { Products } from '../Products/products';
@Component({
  selector: 'app-customers',
  imports: [Products],
  templateUrl: './customers.html',
  styleUrl: './customers.css',
})
export class Customers {
  customername='Salman Khan'
  isEditable=true;
  secretMessage="";
  customerslist=[
    {id:1,name:'Salman Khan'},
    {id:2,name:'Prabhas'},
    {id:3,name:'Sharukh Khan'},
    {id:4,name:'Ranbir Kapoor'}
  ]
  getCustomerNames(): string{
    return this.customerslist.map(customer=>customer.name).join(',');
  }
  starthover(){
    this.secretMessage="Starting the hover effect"
  }
  greet(){
    console.log("Hello From Secret Message")
  }
}

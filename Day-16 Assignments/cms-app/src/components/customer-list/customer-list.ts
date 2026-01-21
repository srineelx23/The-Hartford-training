import { Component } from '@angular/core';
import { Customer } from '../../app/interface/customer';
import { CustomerRepository } from '../../app/repository/customer-repository';
import { OnInit, inject } from '@angular/core';

@Component({
  selector: 'app-customer-list',
  imports: [],
  templateUrl: './customer-list.html',
  styleUrl: './customer-list.css',
})
export class CustomerList{
  // customers:Customer[]=[];
  customerRepo=inject(CustomerRepository);
  customers=this.customerRepo.getCustomers();
}

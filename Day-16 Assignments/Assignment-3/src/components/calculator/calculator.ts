import { Component } from '@angular/core';
import { CalculatorService } from '../../app/services/calculator-service';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-calculator',
  imports: [FormsModule],
  templateUrl: './calculator.html',
  styleUrl: './calculator.css',
})
export class Calculator {
  num1 = 0;
  num2 = 0;
  result = 0;

  constructor(private calcService: CalculatorService) {}

  add() {
    this.result = this.calcService.add(this.num1, this.num2);
  }

  subtract() {
    this.result = this.calcService.subtract(this.num1, this.num2);
  }

  multiply() {
    this.result = this.calcService.multiply(this.num1, this.num2);
  }

  divide() {
    this.result = this.calcService.divide(this.num1, this.num2);
  }

  modulus() {
    this.result = this.calcService.modulus(this.num1, this.num2);
  }
}

import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Calculator } from '../components/calculator/calculator';
import { MessagesComponent } from '../components/messages-component/messages-component';
@Component({
  selector: 'app-root',
  imports: [RouterOutlet,Calculator,MessagesComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Assignment-3');
}

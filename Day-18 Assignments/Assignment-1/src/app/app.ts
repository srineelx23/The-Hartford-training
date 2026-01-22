import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ParentStarComponent } from './components/parent-star-component/parent-star-component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,ParentStarComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Assignment-1');
}

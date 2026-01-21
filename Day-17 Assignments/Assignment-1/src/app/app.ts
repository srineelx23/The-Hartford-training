import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MembersComponent } from '../components/members-component/members-component';
@Component({
  selector: 'app-root',
  imports: [RouterOutlet,MembersComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Assignment-1');
}

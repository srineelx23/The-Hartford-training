import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';


@Component({
  selector: 'app-firstcomponent',
  imports: [RouterOutlet,RouterLink],
  templateUrl: './firstcomponent.html',
  styleUrl: './firstcomponent.css',
})
export class Firstcomponent {

}

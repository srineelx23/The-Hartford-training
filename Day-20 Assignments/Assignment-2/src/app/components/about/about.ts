import { Component, OnInit, signal } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';

@Component({
  selector: 'app-about',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './about.html',
  styleUrl: './about.css',
})
export class About implements OnInit {

  pid = signal(0);
pname = signal('');
pprice = signal(0);

  constructor(public route: ActivatedRoute) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      console.log(params);
      this.pid.set(params['id']);
      this.pname.set(params['name']);
      this.pprice.set(params['price']);
    });
  }
}

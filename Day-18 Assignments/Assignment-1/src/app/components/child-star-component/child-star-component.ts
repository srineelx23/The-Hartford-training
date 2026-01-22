import { Component } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { Output } from '@angular/core';
@Component({
  selector: 'app-child-star-component',
  imports: [],
  templateUrl: './child-star-component.html',
  styleUrl: './child-star-component.css',
})
export class ChildStarComponent {
  selectedStar = 0;   
  hoverStar = 0;      

  @Output() starSelected = new EventEmitter<number>();


  colorStar(star: number) {
    this.selectedStar = star;
    this.starSelected.emit(star);
  }

  onHover(star: number) {
    this.hoverStar = star;
  }

  onLeave() {
    this.hoverStar = 0;
  }

  isFilled(star: number): boolean {
    return star <= (this.hoverStar || this.selectedStar);
  }
}

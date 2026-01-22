import { Component } from '@angular/core';
import { ChildStarComponent } from '../child-star-component/child-star-component';

@Component({
  selector: 'app-parent-star-component',
  imports: [ChildStarComponent],
  templateUrl: './parent-star-component.html',
  styleUrl: './parent-star-component.css',
})
export class ParentStarComponent {
  rating = 0;

  products = [
    {
      id: 1,
      name: 'Noise Cancelling Headphones',
      price: 2999,
      description: 'Immersive sound with active noise cancellation.',
      rating: 0
    },
    {
      id: 2,
      name: 'Mechanical Keyboard',
      price: 4499,
      description: 'Tactile switches with RGB backlighting.',
      rating: 0
    },
    {
      id: 3,
      name: 'Wireless Mouse',
      price: 1499,
      description: 'Ergonomic design with long battery life.',
      rating: 0
    }
  ];

  updateRating(productId: number, rating: number) {
    const product = this.products.find(p => p.id === productId);
    if (product) {
      product.rating = rating;
    }
  }
}

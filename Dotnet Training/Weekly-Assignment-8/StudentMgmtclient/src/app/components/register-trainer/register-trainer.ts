import { Component, inject } from '@angular/core';
import { RouterLink, Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { TrainerService } from '../../services/trainer-service';
import { NotificationService } from '../../services/notification-service';
import { Trainer } from '../../Models/trainer.model';

@Component({
  selector: 'app-register-trainer',
  standalone: true,
  imports: [RouterLink, FormsModule],
  templateUrl: './register-trainer.html',
  styleUrl: './register-trainer.css',
})
export class RegisterTrainer {
  trainerService = inject(TrainerService);
  notificationService = inject(NotificationService);
  router = inject(Router);

  trainer: Trainer = {
    firstName: '',
    lastName: '',
    email: '',
    password: '',
    gender: ''
  };

  register() {
    this.trainerService.register(this.trainer).subscribe({
      next: (response) => {
        console.log(response);
        this.notificationService.showSuccess('Registration successful!');
        this.router.navigate(['/login']);
      },
      error: (err) => {
        console.error('Registration failed:', err);
        this.notificationService.showError('Failed to register. Please try again.');
      }
    });
  }
}

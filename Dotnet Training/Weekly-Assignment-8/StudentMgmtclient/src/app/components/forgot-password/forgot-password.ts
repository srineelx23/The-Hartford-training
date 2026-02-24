import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../services/auth-service';
import { NotificationService } from '../../services/notification-service';

@Component({
  selector: 'app-forgot-password',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './forgot-password.html',
  styleUrl: './forgot-password.css'
})
export class ForgotPassword {
  private authService = inject(AuthService);
  private notificationService = inject(NotificationService);
  private router = inject(Router);

  role: string = 'Student';
  formData = {
    email: '',
    password: '',
    confirmPassword: ''
  };

  onSubmit() {
    if (this.formData.password !== this.formData.confirmPassword) {
      this.notificationService.showError('Passwords do not match. both are not same.');
      return;
    }

    this.authService.forgotPassword(this.role, this.formData.email, this.formData.password).subscribe({
      next: (res: any) => {
        const message = this.role === 'Student' ? 'Student Updated Successfully' : 'Trainer Updated Successfully';
        this.notificationService.showSuccess(message);
        this.router.navigate(['/login']);
      },
      error: (err: any) => {
        console.error('Password reset failed:', err);
        this.notificationService.showError(err.error?.message || 'Failed to update password. Please check your email.');
      }
    });
  }
}

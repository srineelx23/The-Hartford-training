import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../services/auth-service';
import { CaptchaService } from '../../services/captcha.service';
import { NotificationService } from '../../services/notification-service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, RouterLink, FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login implements OnInit {
  authService = inject(AuthService);
  notificationService = inject(NotificationService);
  captchaService = inject(CaptchaService);
  router = inject(Router);

  credentials = {
    email: '',
    password: ''
  };
  role: string = 'Student'; // Default role
  captchaInput: string = '';
  captchaCode = this.captchaService.captcha;

  ngOnInit() {
    this.refreshCaptcha();
  }

  refreshCaptcha() {
    this.captchaService.generateCaptcha();
    this.captchaInput = '';
  }

  login() {
    if (!this.captchaService.verifyCaptcha(this.captchaInput)) {
      this.notificationService.showError('Invalid CAPTCHA code!');
      this.refreshCaptcha();
      return;
    }

    this.authService.login(this.role, this.credentials).subscribe({
      next: (res: any) => {
        console.log('Login successful', res);
        // Navigate based on role
        if (this.role === 'Student') {
          this.router.navigate(['/student-dashboard']);
        } else if (this.role === 'Trainer') {
          this.router.navigate(['/trainer-dashboard']);
        }
      },
      error: (err: any) => {
        console.error('Login failed:', err);
        this.notificationService.showError('Failed to login. Please check your credentials and role.');
        this.refreshCaptcha();
      }
    });
  }
}

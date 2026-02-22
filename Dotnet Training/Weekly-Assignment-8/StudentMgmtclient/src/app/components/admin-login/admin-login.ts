import { Component, inject, OnInit } from '@angular/core';
import { RouterLink, Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../services/auth-service';
import { NotificationService } from '../../services/notification-service';
import { CaptchaService } from '../../services/captcha.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-admin-login',
  standalone: true,
  imports: [RouterLink, FormsModule, CommonModule],
  templateUrl: './admin-login.html',
  styleUrl: './admin-login.css',
})
export class AdminLogin implements OnInit {
  authService = inject(AuthService);
  notificationService = inject(NotificationService);
  captchaService = inject(CaptchaService);
  router = inject(Router);

  credentials = {
    email: '',
    password: ''
  };
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

    this.authService.login('Admin', this.credentials).subscribe({
      next: (res: any) => {
        console.log('Admin login successful', res);
        this.router.navigate(['/admin-dashboard']);
      },
      error: (err: any) => {
        console.error('Admin login failed:', err);
        this.notificationService.showError('Failed to login as Admin. Please check credentials.');
        this.refreshCaptcha();
      }
    });
  }
}

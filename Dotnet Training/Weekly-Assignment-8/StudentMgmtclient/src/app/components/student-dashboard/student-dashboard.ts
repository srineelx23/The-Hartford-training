import { Component, inject, OnInit, signal } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth-service';
import { StudentService } from '../../services/student-service';
import { NotificationService } from '../../services/notification-service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-student-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './student-dashboard.html',
  styleUrl: './student-dashboard.css',
})
export class StudentDashboard implements OnInit {
  authService = inject(AuthService);
  studentService = inject(StudentService);
  notificationService = inject(NotificationService);
  router = inject(Router);

  username: string = '';
  materials = this.studentService.materials;
  loadingMaterials = signal(true);

  constructor() {
    this.username = this.authService.getUsername();
  }

  ngOnInit() {
    this.fetchMaterials();
  }

  fetchMaterials() {
    this.loadingMaterials.set(true);
    this.studentService.getMaterials().subscribe({
      next: () => {
        this.loadingMaterials.set(false);
      },
      error: (err) => {
        console.error('Failed to load materials', err);
        this.loadingMaterials.set(false);
      }
    });
  }

  openMaterial(material: any) {
    if (material.filePath) {
      // The backend saves filePath as "/materials/unique_name.ext"
      // and serves it physically from wwwroot/materials/ via app.UseStaticFiles()
      const backendUrl = `https://localhost:7180${material.filePath}`;
      window.open(backendUrl, '_blank');
    } else {
      console.warn('No file path found for this material:', material);
      this.notificationService.showError('Document URL not available for this material.');
    }
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}

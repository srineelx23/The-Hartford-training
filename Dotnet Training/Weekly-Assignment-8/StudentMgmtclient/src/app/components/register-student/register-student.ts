import { Component, inject } from '@angular/core';
import { RouterLink, Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { StudentService } from '../../services/student-service';
import { NotificationService } from '../../services/notification-service';
import { Student } from '../../Models/Student';

@Component({
  selector: 'app-register-student',
  standalone: true,
  imports: [RouterLink, FormsModule],
  templateUrl: './register-student.html',
  styleUrl: './register-student.css',
})
export class RegisterStudent {
  studentService = inject(StudentService);
  notificationService = inject(NotificationService);
  router = inject(Router);

  student: Student = {
    firstName: '',
    lastName: '',
    email: '',
    password: '',
    age: null,
    gender: '',
    enrollmentDate: new Date().toISOString().split('T')[0]
  };

  register() {
    this.studentService.register(this.student).subscribe({
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

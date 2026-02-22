import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Student } from '../../Models/Student';
import { StudentService } from '../../services/student-service';

@Component({
  selector: 'app-student-form-component',
  imports: [CommonModule, FormsModule],
  templateUrl: './student-form-component.html',
  styleUrl: './student-form-component.css',
})
export class StudentFormComponent {
  newstudent: Student = {
    firstName: '',
    lastName: '',
    age: 0,
    gender: '',
    enrollmentDate: ''
  };

  constructor(public studentService: StudentService) { }
  onSubmit() {
    this.studentService.PostStudent(this.newstudent)
      .subscribe({
        next: (res) => {
          console.log('Saved:', res);
        },
        error: (err) => {
          console.error('Error:', err);
        }
      });
  }
}

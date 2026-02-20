import { inject, Injectable, signal } from '@angular/core';
import { Student } from '../Models/Student';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export class StudentService {
  private readonly apiUrl = 'https://localhost:7180/api/Student';
  private http = inject(HttpClient);

  private _students = signal<Student[]>([]);
  public students = this._students.asReadonly();

  constructor() {
    this.loadStudents();
  }

  loadStudents() {
    this.http.get<Student[]>(this.apiUrl).subscribe({
      next: (students) => this._students.set(students),
      error: (err) => console.error('Error loading students', err)
    });
  }

  PostStudent(student: Student) {
    return this.http.post<Student>(this.apiUrl, student).pipe(
      tap(() => this.loadStudents())
    );
  }

  GetStudents() {
    return this.http.get<Student[]>(this.apiUrl);
  }
}

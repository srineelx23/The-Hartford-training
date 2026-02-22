import { inject, Injectable, signal } from '@angular/core';
import { Student } from '../Models/Student';
import { HttpClient } from '@angular/common/http';
import { tap, Observable } from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export class StudentService {
  private readonly apiUrl = 'https://localhost:7180/api/Student';
  private readonly authUrl = 'https://localhost:7180/api/Auth/student';
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

  register(student: Student): Observable<string> {
    return this.http.post(`${this.authUrl}/register`, student, { responseType: 'text' });
  }

  private _materials = signal<any[]>([]);
  public materials = this._materials.asReadonly();

  getMaterials(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/materials`).pipe(
      tap((res) => {
        let materialsData: any[] = [];
        if (Array.isArray(res)) {
          materialsData = res;
        } else if (res && Array.isArray((res as any).data)) {
          materialsData = (res as any).data;
        } else if (res && Array.isArray((res as any).materials)) {
          materialsData = (res as any).materials;
        }
        this._materials.set(materialsData);
      })
    );
  }
}

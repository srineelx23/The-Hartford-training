import { Injectable, inject, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { Trainer } from '../Models/trainer.model';

@Injectable({
    providedIn: 'root'
})
export class TrainerService {
    private http = inject(HttpClient);
    private readonly authUrl = 'https://localhost:7180/api/Auth';
    private readonly apiUrl = 'https://localhost:7180/api/Trainer';

    // State Signals
    private _students = signal<any[]>([]);
    public students = this._students.asReadonly();

    private _materials = signal<any[]>([]);
    public materials = this._materials.asReadonly();

    register(trainer: Trainer): Observable<string> {
        return this.http.post(`${this.authUrl}/trainer/register`, trainer, { responseType: 'text' });
    }


    // ==== Student Management ====
    getStudents(): Observable<any[]> {
        return this.http.get<any[]>(`${this.apiUrl}/students`).pipe(
            tap((data) => this._students.set(data || []))
        );
    }

    getStudentById(id: number): Observable<any> {
        return this.http.get<any>(`${this.apiUrl}/students/${id}`);
    }

    updateStudent(id: number, data: any): Observable<any> {
        return this.http.put<any>(`${this.apiUrl}/students/${id}`, data);
    }

    deleteStudent(id: number): Observable<any> {
        return this.http.delete<any>(`${this.apiUrl}/students/${id}`);
    }

    addFeedback(feedback: any): Observable<any> {
        return this.http.post<any>(`${this.apiUrl}/AddStudentFeedback`, feedback);
    }

    // ==== Material Management ====
    uploadMaterial(formData: FormData): Observable<any> {
        return this.http.post<any>(`${this.apiUrl}/upload`, formData);
    }

    updateMaterial(materialId: number, data: any): Observable<any> {
        return this.http.put<any>(`${this.apiUrl}/update/${materialId}`, data);
    }

    getMaterials(trainerId: number): Observable<any[]> {
        return this.http.get<any[]>(`${this.apiUrl}/materials/${trainerId}`).pipe(
            tap((data) => this._materials.set(data || []))
        );
    }
}

import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { tap, Observable, map } from 'rxjs';
import { Student } from '../Models/Student';
import { Trainer } from '../Models/trainer.model';

@Injectable({
    providedIn: 'root'
})
export class AdminService {
    private apiUrl = 'https://localhost:7180/api/Admin';
    private http = inject(HttpClient);

    // Signals
    private _students = signal<any[]>([]);
    public students = this._students.asReadonly();

    private _trainers = signal<any[]>([]);
    public trainers = this._trainers.asReadonly();

    private _materials = signal<any[]>([]);
    public materials = this._materials.asReadonly();

    constructor() { }


    // --- Students ---
    getStudents(): Observable<any[]> {
        return this.http.get<any[]>(`${this.apiUrl}/Students`).pipe(
            tap((data) => this._students.set(data || []))
        );
    }

    getStudentById(id: number): Observable<any> {
        return this.http.get<any>(`${this.apiUrl}/Students/${id}`);
    }

    updateStudent(id: number, student: Partial<Student>): Observable<any> {
        return this.http.put(`${this.apiUrl}/Students/Update/${id}`, student).pipe(
            tap(() => this.getStudents().subscribe()) // refresh
        );
    }

    deleteStudent(id: number): Observable<any> {
        return this.http.delete(`${this.apiUrl}/Students/Delete/${id}`).pipe(
            tap(() => this.getStudents().subscribe())
        );
    }

    // --- Trainers ---
    getTrainers(): Observable<any[]> {
        return this.http.get<any[]>(`${this.apiUrl}/Trainers`).pipe(
            tap((data) => this._trainers.set(data || []))
        );
    }

    getTrainerById(id: number): Observable<any> {
        return this.http.get<any>(`${this.apiUrl}/Trainers/${id}`);
    }

    updateTrainer(id: number, trainer: Partial<Trainer>): Observable<any> {
        return this.http.put(`${this.apiUrl}/Trainers/Update/${id}`, trainer).pipe(
            tap(() => this.getTrainers().subscribe()) // refresh
        );
    }

    deleteTrainer(id: number): Observable<any> {
        return this.http.delete(`${this.apiUrl}/Trainers/Delete/${id}`).pipe(
            tap(() => this.getTrainers().subscribe())
        );
    }

    // --- Materials ---
    getMaterials(): Observable<any[]> {
        return this.http.get<any[]>(`${this.apiUrl}/materials`).pipe(
            tap((res) => {
                let items: any[] = [];
                if (Array.isArray(res)) items = res;
                else if (res && Array.isArray((res as any).data)) items = (res as any).data;
                else if (res && Array.isArray((res as any).materials)) items = (res as any).materials;
                this._materials.set(items);
            })
        );
    }

    updateMaterial(id: number, title: string, file: File | null): Observable<any> {
        const formData = new FormData();
        formData.append('Title', title);
        if (file) {
            formData.append('File', file);
        }
        return this.http.put(`${this.apiUrl}/update/${id}`, formData).pipe(
            tap(() => this.getMaterials().subscribe())
        );
    }

    deleteMaterial(id: number): Observable<any> {
        return this.http.delete(`${this.apiUrl}/materials/${id}`).pipe(
            tap(() => this.getMaterials().subscribe())
        );
    }
}

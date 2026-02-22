import { Component, inject, OnInit, signal } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth-service';
import { AdminService } from '../../services/admin-service';
import { NotificationService } from '../../services/notification-service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Student } from '../../Models/Student';
import { Trainer } from '../../Models/trainer.model';

@Component({
  selector: 'app-admin-dashboard',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './admin-dashboard.html',
  styleUrl: './admin-dashboard.css',
})
export class AdminDashboard implements OnInit {
  authService = inject(AuthService);
  adminService = inject(AdminService);
  notificationService = inject(NotificationService);
  router = inject(Router);
  username: string = '';

  // Tabs
  activeTab = signal<'students' | 'trainers' | 'materials'>('students');

  // Service Signals
  students = this.adminService.students;
  trainers = this.adminService.trainers;
  materials = this.adminService.materials;

  // Loading States
  loadingStudents = signal(false);
  loadingTrainers = signal(false);
  loadingMaterials = signal(false);

  // === Modal States ===

  // View Details Modals
  showStudentDetailsModal = signal(false);
  studentDetails = signal<any>(null);

  showTrainerDetailsModal = signal(false);
  trainerDetails = signal<any>(null);

  // Edit Modals
  showEditStudentModal = signal(false);
  currentStudent: any = null;
  editStudentData: Partial<Student> = {};

  showEditTrainerModal = signal(false);
  currentTrainer: any = null;
  editTrainerData: Partial<Trainer> = {};

  showEditMaterialModal = signal(false);
  currentMaterial: any = null;
  editMaterialTitle: string = '';
  editSelectedFile: File | null = null;

  constructor() {
    this.username = this.authService.getUsername();
  }

  ngOnInit() {
    this.loadData();
  }

  switchTab(tab: 'students' | 'trainers' | 'materials') {
    this.activeTab.set(tab);
    if (tab === 'students' && this.students().length === 0) this.loadStudents();
    if (tab === 'trainers' && this.trainers().length === 0) this.loadTrainers();
    if (tab === 'materials' && this.materials().length === 0) this.loadMaterials();
  }

  loadData() {
    this.loadStudents();
    this.loadTrainers();
    this.loadMaterials();
  }

  // --- Loaders ---
  loadStudents() {
    this.loadingStudents.set(true);
    this.adminService.getStudents().subscribe({
      next: () => this.loadingStudents.set(false),
      error: (err) => { console.error(err); this.loadingStudents.set(false); }
    });
  }

  loadTrainers() {
    this.loadingTrainers.set(true);
    this.adminService.getTrainers().subscribe({
      next: () => this.loadingTrainers.set(false),
      error: (err) => { console.error(err); this.loadingTrainers.set(false); }
    });
  }

  loadMaterials() {
    this.loadingMaterials.set(true);
    this.adminService.getMaterials().subscribe({
      next: () => this.loadingMaterials.set(false),
      error: (err) => { console.error(err); this.loadingMaterials.set(false); }
    });
  }

  // --- Student Actions ---
  viewStudentDetails(student: any) {
    this.adminService.getStudentById(student.studentId).subscribe({
      next: (data) => {
        this.studentDetails.set(data);
        this.showStudentDetailsModal.set(true);
      },
      error: () => this.notificationService.showError('Failed to load student')
    });
  }
  closeStudentDetails() { this.showStudentDetailsModal.set(false); }

  openEditStudent(student: any) {
    this.currentStudent = student;
    this.editStudentData = { ...student };
    this.showEditStudentModal.set(true);
  }
  closeEditStudent() { this.showEditStudentModal.set(false); }

  saveStudent() {
    if (!this.currentStudent) return;
    this.adminService.updateStudent(this.currentStudent.studentId, this.editStudentData).subscribe({
      next: () => {
        this.notificationService.showSuccess('Student updated successfully');
        this.closeEditStudent();
      },
      error: () => this.notificationService.showError('Failed to update student')
    });
  }

  deleteStudent(studentId: number) {
    if (confirm('Are you sure you want to delete this student?')) {
      this.adminService.deleteStudent(studentId).subscribe({
        next: () => this.notificationService.showSuccess('Student deleted'),
        error: () => this.notificationService.showError('Failed to delete student')
      });
    }
  }

  // --- Trainer Actions ---
  viewTrainerDetails(trainer: any) {
    this.adminService.getTrainerById(trainer.trainerId).subscribe({
      next: (data) => {
        this.trainerDetails.set(data);
        this.showTrainerDetailsModal.set(true);
      },
      error: () => this.notificationService.showError('Failed to load trainer')
    });
  }
  closeTrainerDetails() { this.showTrainerDetailsModal.set(false); }

  openEditTrainer(trainer: any) {
    this.currentTrainer = trainer;
    this.editTrainerData = { ...trainer };
    this.showEditTrainerModal.set(true);
  }
  closeEditTrainer() { this.showEditTrainerModal.set(false); }

  saveTrainer() {
    if (!this.currentTrainer) return;
    this.adminService.updateTrainer(this.currentTrainer.trainerId, this.editTrainerData).subscribe({
      next: () => {
        this.notificationService.showSuccess('Trainer updated successfully');
        this.closeEditTrainer();
      },
      error: () => this.notificationService.showError('Failed to update trainer')
    });
  }

  deleteTrainer(trainerId: number) {
    if (confirm('Are you sure you want to delete this trainer?')) {
      this.adminService.deleteTrainer(trainerId).subscribe({
        next: () => this.notificationService.showSuccess('Trainer deleted'),
        error: () => this.notificationService.showError('Failed to delete trainer')
      });
    }
  }

  // --- Material Actions ---
  openMaterial(material: any) {
    const url = `https://localhost:7180${material.filePath}`;
    window.open(url, '_blank');
  }

  openEditMaterial(material: any) {
    this.currentMaterial = material;
    this.editMaterialTitle = material.title || '';
    this.editSelectedFile = null;
    this.showEditMaterialModal.set(true);
  }
  closeEditMaterial() { this.showEditMaterialModal.set(false); }

  onEditFileSelected(event: any) {
    if (event.target.files.length > 0) {
      this.editSelectedFile = event.target.files[0];
    }
  }

  saveMaterial() {
    if (!this.currentMaterial || !this.editMaterialTitle) return;
    this.adminService.updateMaterial(
      this.currentMaterial.studyMaterialId,
      this.editMaterialTitle,
      this.editSelectedFile
    ).subscribe({
      next: () => {
        this.notificationService.showSuccess('Material updated successfully!');
        this.closeEditMaterial();
      },
      error: () => this.notificationService.showError('Failed to update material.')
    });
  }

  deleteMaterial(materialId: number) {
    if (confirm('Are you sure you want to delete this material?')) {
      this.adminService.deleteMaterial(materialId).subscribe({
        next: () => this.notificationService.showSuccess('Material deleted'),
        error: () => this.notificationService.showError('Failed to delete material')
      });
    }
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}

import { Component, inject, OnInit, signal } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../services/auth-service';
import { TrainerService } from '../../services/trainer-service';
import { NotificationService } from '../../services/notification-service';
import { Student } from '../../Models/Student';

@Component({
  selector: 'app-trainer-dashboard',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './trainer-dashboard.html',
  styleUrl: './trainer-dashboard.css',
})
export class TrainerDashboard implements OnInit {
  authService = inject(AuthService);
  trainerService = inject(TrainerService);
  notificationService = inject(NotificationService);
  router = inject(Router);

  username: string = '';
  trainerId: number = 0;

  activeTab: 'students' | 'materials' = 'students';

  // State Signals from Service
  students = this.trainerService.students;
  materials = this.trainerService.materials;

  loadingStudents = signal(false);
  loadingMaterials = signal(false);

  // Modals state
  showFeedbackModal = signal(false);
  showMaterialModal = signal(false);
  showEditMaterialModal = signal(false);
  showEditStudentModal = signal(false);
  showStudentDetailsModal = signal(false);

  // Form Data
  currentStudent: any = null;
  studentDetails = signal<any>(null);
  currentMaterial: any = null;
  feedbackText: string = '';

  materialTitle: string = '';
  selectedFile: File | null = null;

  editMaterialTitle: string = '';
  editSelectedFile: File | null = null;

  editStudentData: Partial<Student> = {};

  constructor() {
    this.username = this.authService.getUsername();
    const idStr = this.authService.getUserId();
    this.trainerId = idStr ? parseInt(idStr, 10) : 0;
  }

  ngOnInit() {
    this.loadStudents();
    if (this.trainerId) {
      this.loadMaterials();
    } else {
      console.warn("No trainer ID found. Won't load materials automatically.");
    }
  }

  setTab(tab: 'students' | 'materials') {
    this.activeTab = tab;
  }

  loadStudents() {
    this.loadingStudents.set(true);
    this.trainerService.getStudents().subscribe({
      next: () => {
        this.loadingStudents.set(false);
      },
      error: (err) => {
        console.error('Error loading students', err);
        this.loadingStudents.set(false);
      }
    });
  }

  loadMaterials() {
    this.loadingMaterials.set(true);
    this.trainerService.getMaterials(this.trainerId).subscribe({
      next: () => {
        this.loadingMaterials.set(false);
      },
      error: (err) => {
        console.error('Error loading materials', err);
        this.loadingMaterials.set(false);
      }
    });
  }

  // ==== Student Modals Actions ====

  viewStudentDetails(student: any) {
    this.trainerService.getStudentById(student.studentId).subscribe({
      next: (data) => {
        this.studentDetails.set(data);
        this.showStudentDetailsModal.set(true);
      },
      error: (err) => {
        console.error('Error fetching student details', err);
        this.notificationService.showError('Failed to load student details.');
      }
    });
  }

  closeStudentDetails() {
    this.showStudentDetailsModal.set(false);
    this.studentDetails.set(null);
  }

  // ==== Student Actions ====
  openEditStudent(student: Student) {
    this.currentStudent = student;
    this.editStudentData = { ...student };
    this.showEditStudentModal.set(true);
  }

  closeEditStudent() {
    this.showEditStudentModal.set(false);
    this.currentStudent = null;
  }

  saveStudent() {
    if (!this.currentStudent?.studentId) return;

    this.trainerService.updateStudent(this.currentStudent.studentId, this.editStudentData).subscribe({
      next: () => {
        this.loadStudents();
        this.closeEditStudent();
      },
      error: (err) => {
        console.error('Failed to update student', err);
        this.notificationService.showError('Failed to update student.');
      }
    });
  }

  deleteStudent(id: number | undefined) {
    if (!id) return;
    if (confirm('Are you sure you want to delete this student?')) {
      this.trainerService.deleteStudent(id).subscribe({
        next: () => this.loadStudents(),
        error: (err) => {
          console.error('Failed to delete student', err);
          this.notificationService.showError('Failed to delete student.');
        }
      });
    }
  }

  // ==== Feedback Actions ====
  openFeedback(student: Student) {
    this.currentStudent = student;
    this.feedbackText = '';
    this.showFeedbackModal.set(true);
  }

  closeFeedback() {
    this.showFeedbackModal.set(false);
    this.currentStudent = null;
  }

  submitFeedback() {
    if (!this.currentStudent?.studentId || !this.feedbackText.trim()) return;

    const payload = {
      feedbackId: 0,
      feedback: this.feedbackText,
      studentId: this.currentStudent.studentId,
      trainerId: this.trainerId,
      trainerName: this.username,
      feedbackDate: new Date().toISOString().split('T')[0]
    };

    this.trainerService.addFeedback(payload).subscribe({
      next: () => {
        this.notificationService.showSuccess('Feedback submitted!');
        this.closeFeedback();
      },
      error: (err) => {
        console.error('Error submitting feedback', err);
        this.notificationService.showError('Failed to submit feedback.');
      }
    });
  }

  // ==== Material Actions ====
  openUploadMaterial() {
    this.materialTitle = '';
    this.selectedFile = null;
    this.showMaterialModal.set(true);
  }

  closeMaterialModal() {
    this.showMaterialModal.set(false);
  }

  onFileSelected(event: any) {
    const file: File = event.target.files[0];
    if (file) {
      this.selectedFile = file;
    }
  }

  uploadMaterial() {
    if (!this.selectedFile) return;

    const formData = new FormData();
    formData.append('file', this.selectedFile);
    formData.append('title', this.materialTitle || this.selectedFile.name);
    // Passing trainerId so backend knows who owns the material
    formData.append('trainerId', this.trainerId.toString());

    this.trainerService.uploadMaterial(formData).subscribe({
      next: () => {
        this.notificationService.showSuccess('Material uploaded!');
        this.closeMaterialModal();
        this.loadMaterials();
      },
      error: (err) => {
        console.error('Error uploading material', err);
        this.notificationService.showError('Failed to upload material.');
      }
    });
  }

  // ==== Material Edit Actions ====
  openEditMaterial(material: any) {
    this.currentMaterial = material;
    this.editMaterialTitle = material.title || '';
    this.editSelectedFile = null;
    this.showEditMaterialModal.set(true);
  }

  closeEditMaterial() {
    this.showEditMaterialModal.set(false);
    this.currentMaterial = null;
  }

  onEditFileSelected(event: any) {
    const file: File = event.target.files[0];
    if (file) {
      this.editSelectedFile = file;
    }
  }

  saveMaterial() {
    if (!this.currentMaterial?.studyMaterialId) return;

    const formData = new FormData();
    if (this.editSelectedFile) {
      formData.append('file', this.editSelectedFile);
    }
    formData.append('title', this.editMaterialTitle || (this.editSelectedFile ? this.editSelectedFile.name : this.currentMaterial.title));

    this.trainerService.updateMaterial(this.currentMaterial.studyMaterialId, formData).subscribe({
      next: () => {
        this.notificationService.showSuccess('Material updated!');
        this.closeEditMaterial();
        this.loadMaterials();
      },
      error: (err) => {
        console.error('Error updating material', err);
        this.notificationService.showError('Failed to update material.');
      }
    });
  }

  // ==== Material View Action ====
  openMaterial(material: any) {
    if (material.filePath) {
      // The backend saves filePath as "/materials/unique_name.ext"
      // and serves it physically from wwwroot/materials/ via app.UseStaticFiles()
      const backendUrl = `https://localhost:7180${material.filePath}`;
      window.open(backendUrl, '_blank');
    }
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}


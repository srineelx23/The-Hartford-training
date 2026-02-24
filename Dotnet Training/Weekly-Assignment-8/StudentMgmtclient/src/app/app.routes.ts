import { Routes } from '@angular/router';
import { LandingPage } from './components/landing-page/landing-page';
import { RegisterStudent } from './components/register-student/register-student';
import { RegisterTrainer } from './components/register-trainer/register-trainer';
import { Login } from './components/login/login';
import { AdminLogin } from './components/admin-login/admin-login';
import { StudentDashboard } from './components/student-dashboard/student-dashboard';
import { TrainerDashboard } from './components/trainer-dashboard/trainer-dashboard';
import { AdminDashboard } from './components/admin-dashboard/admin-dashboard';
import { ForgotPassword } from './components/forgot-password/forgot-password';
import { authGuard } from './guards/auth-guard';

export const routes: Routes = [
    { path: '', component: LandingPage },
    { path: 'register-student', component: RegisterStudent },
    { path: 'register-trainer', component: RegisterTrainer },
    { path: 'login', component: Login },
    { path: 'forgot-password', component: ForgotPassword },
    { path: 'admin-panel', component: AdminLogin },
    { path: 'student-dashboard', component: StudentDashboard, canActivate: [authGuard] },
    { path: 'trainer-dashboard', component: TrainerDashboard, canActivate: [authGuard] },
    { path: 'admin-dashboard', component: AdminDashboard, canActivate: [authGuard] },
    { path: '**', redirectTo: '' }
];

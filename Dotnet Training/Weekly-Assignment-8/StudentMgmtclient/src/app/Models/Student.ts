export interface Student {
    firstName: string;
    lastName: string;
    email?: string;
    password?: string;
    age: number | null;
    gender: string;
    enrollmentDate: string;
    studentId?: number;
}
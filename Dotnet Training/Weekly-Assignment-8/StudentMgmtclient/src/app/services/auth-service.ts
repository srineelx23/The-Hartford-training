import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    private http = inject(HttpClient);
    private authUrl = 'https://localhost:7180/api/Auth';

    login(role: string, credentials: any): Observable<any> {
        const endpoint = `${this.authUrl}/${role.toLowerCase()}/login`;
        return this.http.post(endpoint, credentials).pipe(
            tap((response: any) => {
                if (response && response.token) {
                    sessionStorage.setItem('token', response.token);
                    sessionStorage.setItem('role', role);

                    // The backend returns the user's name in the 'email' property of the response
                    let username = response.email || response.userName;
                    let userId = response.id || response.userId;

                    try {
                        const payloadBase64 = response.token.split('.')[1];
                        const decodedClaims = JSON.parse(atob(payloadBase64));

                        if (!username) {
                            username = decodedClaims['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name']
                                || decodedClaims['unique_name']
                                || decodedClaims['name']
                                || credentials.email;
                        }

                        if (!userId) {
                            userId = decodedClaims['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier']
                                || decodedClaims['nameid']
                                || decodedClaims['sub'];
                        }
                    } catch (e) {
                        console.error('Failed to parse JWT payload', e);
                        username = username || credentials.email || 'User';
                    }

                    sessionStorage.setItem('username', username || 'User');
                    if (userId) sessionStorage.setItem('userId', userId.toString());
                }
            })
        );
    }

    getToken(): string | null {
        return sessionStorage.getItem('token');
    }

    getUsername(): string {
        return sessionStorage.getItem('username') || 'User';
    }

    getUserId(): string | null {
        return sessionStorage.getItem('userId');
    }

    isLoggedIn(): boolean {
        return !!this.getToken();
    }

    logout(): void {
        sessionStorage.removeItem('token');
        sessionStorage.removeItem('role');
        sessionStorage.removeItem('username');
        sessionStorage.removeItem('userId');
    }

    forgotPassword(role: string, email: string, password: string): Observable<any> {
        const endpoint = `${this.authUrl}/${role.toLowerCase()}/forgotpassword?email=${email}&password=${password}`;
        return this.http.put(endpoint, {}, { responseType: 'text' });
    }
}

import { Injectable, signal } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class CaptchaService {
    private captchaText = signal('');

    get captcha() {
        return this.captchaText.asReadonly();
    }

    generateCaptcha(): string {
        const chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789';
        let result = '';
        for (let i = 0; i < 6; i++) {
            result += chars.charAt(Math.floor(Math.random() * chars.length));
        }
        this.captchaText.set(result);
        return result;
    }

    verifyCaptcha(input: string): boolean {
        return input.toUpperCase() === this.captchaText().toUpperCase();
    }
}

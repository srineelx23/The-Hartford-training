import { Injectable, signal } from '@angular/core';

export type NotificationType = 'success' | 'error' | 'info';

@Injectable({
    providedIn: 'root'
})
export class NotificationService {
    notification = signal<{ message: string; type: NotificationType } | null>(null);

    showSuccess(message: string) {
        this.notify(message, 'success');
    }

    showError(message: string) {
        this.notify(message, 'error');
    }

    showInfo(message: string) {
        this.notify(message, 'info');
    }

    private notify(message: string, type: NotificationType) {
        this.notification.set({ message, type });
        setTimeout(() => {
            if (this.notification()?.message === message) {
                this.clear();
            }
        }, 4000);
    }

    clear() {
        this.notification.set(null);
    }
}

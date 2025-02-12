import { Injectable, TemplateRef } from '@angular/core';


@Injectable({ providedIn: 'root' })
export class ToastService {
  toasts: any[] = [];

  success(message: string) {
    this.show(message, 'success', { classname: 'bg-success text-light', delay: 5000 });
  }

  error(message: string) {
    this.show(message, 'error', { classname: 'bg-danger text-light', delay: 5000 });
  }

  info(message: string) {
    this.show(message, 'info', { classname: 'bg-info text-light', delay: 5000 });
  }

  warning(message: string) {
    this.show(message, 'warning', { classname: 'bg-warning text-light', delay: 5000 });
  }

  // main alert method
  show(textOrTpl: string | TemplateRef<any>, type: string, options: any = {}) {
    this.toasts.push({ textOrTpl, type, ...options });
  }


  remove(toast: any) {
    this.toasts = this.toasts.filter(t => t !== toast);
  }
}

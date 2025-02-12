import { Component, TemplateRef } from '@angular/core';
import { ToastService } from '../../services/toast/toast.service';

@Component({
  selector: 'app-toasts',
  template: `
    <ngb-toast
      *ngFor="let toast of toastService.toasts"
      [class]="toast.classname"
      [autohide]="true"
      [delay]="toast.delay || 5000"
      (hidden)="toastService.remove(toast)"
      (click)="toastService.remove(toast)"
    >

      <div style="margin-left: 5px;margin-right: 10px;margin-top: auto;margin-bottom: auto;">
        <i class="fas fa-times-circle fa-2x" *ngIf="toast.type=='error'"></i>
        <i class="fas fa-info-circle fa-2x" *ngIf="toast.type=='info'"></i>
        <i class="fas fa-exclamation-triangle fa-2x" *ngIf="toast.type=='warning'"></i>
        <i class="fas fa-check-circle fa-2x" *ngIf="toast.type=='success'"></i>
      </div>
      
      <div style="margin-top: auto;margin-bottom: auto;">{{ toast.textOrTpl }}</div>
    </ngb-toast>
  `,
  host: { 'class': 'toast-container position-fixed top-0 end-0 p-3', 'style': 'z-index: 1200' },
  styles: ['.toast-body { display: flex; }']
})
export class ToastsComponent{
  constructor(public toastService: ToastService) { }

  isTemplate(toast: any) {  return toast.textOrTpl instanceof TemplateRef; }
}

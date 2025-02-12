import { CommonModule, DecimalPipe } from '@angular/common';
import { ModuleWithProviders, NgModule } from '@angular/core';
import { AlertComponent } from './components/alert/alert.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbAlertModule, NgbModule, NgbPaginationModule, NgbToastModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxMaskModule } from 'ngx-mask';
import { DialogDeleteComponent } from './components/dialog-delete/dialog-delete.component';
import { ErrorMsgComponent } from './components/error/error-msg.component';
import { SkeletonTableComponent } from './components/skeleton-table/skeleton-table.component';
import { ToastsComponent } from './components/toast/toast.component';

@NgModule({
  imports: [
    CommonModule,
    NgbModule,
    NgbPaginationModule,
    NgbAlertModule,
    NgbToastModule,
    FormsModule,
    ReactiveFormsModule,
    NgxMaskModule.forRoot(),
  ],
  declarations: [
    AlertComponent,
    ErrorMsgComponent,
    DialogDeleteComponent,
    ToastsComponent,
    SkeletonTableComponent,
  ],
  exports: [
    // Componentes
    AlertComponent,
    ToastsComponent,
    ErrorMsgComponent,
    NgbModule,
    NgbAlertModule,
    NgbToastModule,
    NgbPaginationModule,
    FormsModule,
    ReactiveFormsModule,
    NgxMaskModule,
    SkeletonTableComponent
  ],
  providers: [
    DecimalPipe,
  ]
})
export class SharedModule {
  static forRoot(): ModuleWithProviders<SharedModule> {
    return {
      ngModule: SharedModule
    };
  }
}

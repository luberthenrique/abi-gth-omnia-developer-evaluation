import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { Inject, LOCALE_ID, NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { CommonModule, registerLocaleData } from '@angular/common';
import localePt from '@angular/common/locales/pt';
import { SharedModule } from '../shared/shared.module';
import { CoreRoutingModule } from './core.routing';
import { ErrorInterceptor } from './interceptors/error.interceptor';


registerLocaleData(localePt);

@NgModule({
  imports: [
    CommonModule,
    RouterModule, 
    HttpClientModule,
    NgbModule,
    SharedModule,
    CoreRoutingModule
  ],
  declarations: [
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    { provide: LOCALE_ID, useValue: 'pt-BR' }
  ]
})
export class CoreModule{
  baseUrl = ''
  constructor(
    @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;

  }
}

